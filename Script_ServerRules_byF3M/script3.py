#!/usr/bin/env python3

from tkinter import filedialog
from tkinter import *
import fileinput
import sys
import re
import os
from colorama import init
import numpy as np 
init()

# defined data
begin_of_parameter = 'in'
variables = {
    r'^int$': r'^int',
    r'^string$': r'^str',
    r'^bool$': r'^bln',
    r'^DateTime$': r'^dt',
    r'^long$': r'^lng',
    r'^List<[^\>]+>$': r'^lst',
    r'^Dictionary<[^\,]+,[^\>]+>$': r'^dic',
    r'^[A-Za-z0-9\_]+\[\]$': r'^arr'
}

# code data
in_comment = 0
in_function = 0
functions_documentation = {}
input_results = {}
functions_variables = {}
documentation = ""
d_params = []
d_ok = False
d_params_wrong = {}

def readFilesFromPath(path):
    files = []
    files = os.listdir(path)
    return files

def regex_keys(in_key, line):
    in_key += line.count('{')
    in_key -= line.count('}')
    keys_instring_regex = re.findall('[\'\"]([^\'\"]*[{}][^\'\"]*)+[\'\"]', line)
    if (keys_instring_regex):
        for st in keys_instring_regex :
            in_key -= st.count('{')
            in_key += st.count('}')
    return in_key

def testFile(path, file):
    global in_comment
    global in_function
    global documentation
    global d_params
    global d_ok
    global d_params_wrong
    in_key = 0 # for testing '{' '}' 
    class_name = file[:len(file)-3]
   
    for line in fileinput.input(path):

        function_in_line = re.match(r'\s*(public|private)\s+(async\s+)?(void|[A-Za-z][A-Za-z0-9\<\>\_?\[\]]*)\s+[A-Z][A-Za-z0-9\_]*\s*\(.*\)', line)

        is_comment = re.match(r'\s*///\s*(.*)\s*', line)

        # detect init of function
        if function_in_line:
            in_function = 1
            in_key = regex_keys(in_key,line)
            func = re.sub(r'^\s*', r'', function_in_line.group())
            input_results[func] = []
            functions_variables[func] = []

            # Input names must begin by "in"
            params_search = re.search(r'\(.+\)', func)
            if (params_search):
                params = params_search.group().split(',')
                i = 0

                while(i < len(params)) :
                    params[i] = params[i].replace(r'(','').replace(r')','')
                    split_by_space = re.split(r'\s+', params[i])
                    input_to_test = split_by_space[-1]
                    params[i] = input_to_test
                    tested = (input_to_test[:2] == begin_of_parameter)
                    if not tested :
                        input_results[func].append(input_to_test)
                    i+=1

                if (documentation != ""):
                    # has documentation
                    if (not d_ok):
                        # documentation is not ok
                        functions_documentation[func] = -1
                    else:
                        # test parameters
                        equals = np.array_equal(params, d_params)
                        if (equals):
                            # params are ok
                            functions_documentation[func] = 1
                        else:
                            # params are wrong
                            functions_documentation[func] = 0
                            d_params_wrong[func] = (params, d_params)

                else:
                    # no documentation
                    functions_documentation[func] = -2
    
                documentation = ""
                d_params = []

        # detect it is inside function
        elif in_function == 1:
            in_key = regex_keys(in_key,line)
            if ("}" in line and in_comment == 0 and in_key == 0):
                in_function = 0
            
            #Testing variables names

            variable_test = re.search(r'([A-Za-z0-9\[\]\_\<\>,?]+)\s+([A-Za-z0-9\_.]+)\s*=[^;]+\s*;', line)
            if (variable_test):

                type = variable_test.groups()[0]
                name = variable_test.groups()[1]
                split_text = [type, name]
                for variable in variables:
                    if re.match(variable, type):
                        if re.match(variables[variable], name):
                            split_text.append(1)
                        else:
                            split_text.append(0)
                functions_variables[func].append(split_text)

        # Comments testing        
        elif is_comment:
            if (not in_comment):
                in_comment = 1
                documentation = ""
            documentation = documentation + is_comment.groups()[0]

        elif in_comment:
            in_comment = 0
            correct_documentation = re.match(r'<summary>[^<]+</summary>((?:<param name="[^\"]+">[^<]+</param>)*)<returns>[^<]+</returns><example><code>[^<]+</code></example>', documentation)
            if (correct_documentation):
                # documentation ok
                d_ok = True
                params = correct_documentation.groups()[0]
                d_params = re.findall(r'<param name="([^\"]+)">[^<]+</param>', params)
            else: 
                # documentation not ok
                d_ok = False

def cleanData():
    in_comment = 0
    in_function = 0
    functions_documentation.clear()
    input_results.clear()
    functions_variables.clear()
    d_params.clear()
    d_params_wrong.clear()
    documentation = ""
    d_params.clear()

def printResults ():
    flag = 0
    
    for key in input_results.keys():
        if (input_results[key]) :
            if (flag == 0):
                print('\033[1m' + '---> FUNCTIONS INPUT\'S:' + '\033[0m\n')
            flag += 1
            print("-> Function \033[4m" + key + "\033[0m:")
            for inp in input_results[key]:
                print('\033[91m\033[1m' + u'\u274C' + '\033[0m  ' + "Missing 'in' in the input parameter \033[93m" + inp + "\033[0m")
    
    if (functions_documentation):
        print('\033[1m' + '\n---> FUNCTIONS DOCUMENTATION:' + '\033[0m\n')
        bad = '\033[91m\033[1m' + u'\u274C' + '\033[0m ' + ' '
        good = '\033[92m\033[1m' + u'\u2714' + '\033[0m ' + ' '
        
        for func in functions_documentation:
            if (functions_documentation[func] == -2):
                print(bad + func + ': no documentation')
            elif (functions_documentation[func] == -1):
                print(bad + func + ': Documentation is not correct')
            elif (functions_documentation[func] == 0):
                print(bad + func + ': Parameters of function are different from the documentation')
                print('\tFunction params = ' + str(d_params_wrong[func][0]))
                print('\tDocumentation params = ' + str(d_params_wrong[func][1]))
            else:
                print(good + func)
    
    print_f = any(value for value in functions_variables.values())
    if (functions_variables and print_f):
        print('\033[1m' + '\n---> VARIABLES NAME RULE:' + '\033[0m\n')
        for key in functions_variables:
            if (functions_variables[key]):
                print("-> Function \033[4m" + key +  "\033[0m:")
                for variable in functions_variables.get(key):
                    x = ""
                    if (variable[2]==0):
                        x = '\033[91m\033[1m' + u'\u274C' + '\033[0m ' + ' '
                    else:
                        x = '\033[92m\033[1m' + u'\u2714' + '\033[0m ' + ' '
                    print(x + variable[0] + ' ' + variable[1] )


def printResultsToGUI (text):
    flag = 0
    
    good = u'\u2714'
    bad =  u'\u274C'
    for key in input_results.keys():
        if (input_results[key]) :
            if (flag == 0):
                text.insert(INSERT,'---> FUNCTIONS INPUT\'S:\n',["white","bold"])
            flag += 1
            text.insert(INSERT,"\n-> Function " + key + ":",["white"])
            for inp in input_results[key]:
                text.insert(INSERT,"\n")
                text.insert(INSERT,bad,["red","bold"])
                text.insert(INSERT,"  Missing 'in' in the input parameter " ,["white"])
                text.insert(INSERT, inp, "yellow")
    
    if (functions_documentation):
        text.insert(INSERT,'\n\n---> FUNCTIONS DOCUMENTATION:\n',["white","bold"])
        
        for func in functions_documentation:
            text.insert(INSERT,"\n")
            if (functions_documentation[func] == -2):
                text.insert(INSERT,bad,["red","bold"])
                text.insert(INSERT," " + func + ': no documentation' ,"white")
            elif (functions_documentation[func] == -1):
                text.insert(INSERT,bad,["red","bold"])
                text.insert(INSERT, " "+ func + ': Documentation is not correct',"white")
            elif (functions_documentation[func] == 0):
                text.insert(INSERT,bad,["red","bold"])
                text.insert(INSERT," "+ func + ': Parameters of function are different from the documentation' ,"white")
                text.insert(INSERT,'\n\tFunction params = ' + str(d_params_wrong[func][0]) ,"white")
                text.insert(INSERT,'\n\tDocumentation params = ' + str(d_params_wrong[func][1]) ,"white")

            else:
                text.insert(INSERT,good,["green","bold"])
                text.insert(INSERT, " " + func,"white")    
    print_f = any(value for value in functions_variables.values())
    if (functions_variables and print_f):
        text.insert(INSERT,'\n\n---> VARIABLES NAME RULE:\n',["white","bold"])
        for key in functions_variables:
            if (functions_variables[key]):
                text.insert(INSERT,"\n-> Function " + key + ":",["white"])
                for variable in functions_variables.get(key):
                    text.insert(INSERT,"\n")
                    x = ""
                    if (variable[2]==0):
                        text.insert(INSERT,bad,["red","bold"])
                    else:
                        text.insert(INSERT,good,["green","bold"])
                    text.insert(INSERT," " + variable[0] + ' ' + variable[1] ,["white"])
    return text

def printToGUI(text,path):
    files = readFilesFromPath(path)
    nfiles = len(files)
    nTested = 0
    text.insert(INSERT,'\n--------------------> ' + str(nfiles) + ' FILES TO TEST <--------------------\n',["white","center","bold"])
    while nTested<nfiles :
        text.insert(INSERT,"\n-------> ",["center","normal","blue"])
        text.insert(INSERT,files[nTested],["center","underline","blue"])
        text.insert(INSERT," <-------\n",["center","normal","blue"])
        testFile(path + "/"+ files[nTested],files[nTested])
        text = printResultsToGUI(text)
        cleanData()
        nTested+=1
    return text
 

if __name__ == '__main__':
    files = readFilesFromPath(sys.argv[1])
    nfiles = len(files)
    nTested = 0
    print('\033[1m' + '\n--------------------> ' + str(nfiles) + ' FILES TO TEST <--------------------' + '\033[0m')
    while nTested<nfiles :
        print('\033[34m' + '\033[1m' + '\n-------> ' + '\033[0m' + '\033[34m' + '\033[1m' + '\033[4m' + files[nTested] + '\033[0m' + '\033[34m' + '\033[1m' + ' <-------' + '\033[0m\n')
        testFile(sys.argv[1] + "/"+ files[nTested],files[nTested])
        printResults()
        cleanData()
        nTested+=1



# To use this script use :
#  on Linux:
#   $ chmod +x script3.py
#   $ ./script3.py PathToFiles
#      example:
#      $ ./script3.py Files
#  on Windows:
#   $ python ./script3.py PathToFiles
#      example:
#      $ python ./script3.py Files
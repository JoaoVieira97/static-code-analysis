#!/usr/bin/env python3

import fileinput
import sys
import re
import os
from colorama import init
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

def readFilesFromPath(path):
  files = []
  files = os.listdir(path)
  return files

def testFile(path, file):
   global in_comment
   global in_function
   in_key = 0 # for testing '{' '}' 
   class_name = file[:len(file)-3]
   
   for line in fileinput.input(path):

        #function_in_line = re.match(r'\s*(public|private)\s*[a-zA-Z](?!lass)(?!' + class_name[1:] + r').*\(.*\)', line)
        function_in_line = re.match(r'\s*(public|private)\s+(async\s+)?(void|[A-Za-z][A-Za-z0-9\<\>\_?\[\]]*)\s+[A-Z][A-Za-z0-9\_]*\s*\(.*\)', line)
        # detect init of function
        if function_in_line:
            in_function = 1
            in_key+=line.count('{')
            in_key-=line.count('}')
            func = re.sub(r'^\s*', r'', function_in_line.group())
            input_results[func] = []
            functions_variables[func] = []
            if (in_comment != 8) :
                functions_documentation[func] = 0
            else:
                functions_documentation[func] = 1
                in_comment = 0
    
            # Input names must begin by "in"
            params_search = re.search(r'\(.+\)', func)
            if (params_search):
                params = params_search.group().split(',')
                i = 0

                while(i < len(params)) :
                    params[i] = params[i].replace(r'(','').replace(r')','')
                    split_by_space = re.split(r'\s+', params[i])
                    input_to_test = split_by_space[-1]
                    tested = (input_to_test[:2] == begin_of_parameter)
                    if not tested :
                        input_results[func].append(input_to_test)
                    i+=1

        # detect it is inside function
        elif in_function == 1:
            in_key+=line.count('{')
            in_key-=line.count('}')
            
            if ("}" in line and in_comment == 0 and in_key<=0) : # end of function -> TODO
                in_function = 0
            
            #Testing variables names

            #variable_test = re.search(r'(public|private)\s*[^\s]+\s+[A-Za-z]+[^=;\s]*', line)
            variable_test = re.search(r'([A-Za-z0-9\[\]\_\<\>,?]+)\s+([A-Za-z0-9\_.]+)\s*=[^;]+\s*;', line)
            if (variable_test):
             #   print(variable_test.groups())
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
        elif in_function == 0 and in_comment != 8:
            if ("///" not in line):
                in_comment = 0
            else :
                if (in_comment == 0 ) : # begin of summary
                    if ("<summary>" in line):
                        in_comment+=1
                elif (in_comment == 1): # end of summary
                    if ("</summary>" in line):
                        in_comment+=1
                elif (in_comment == 2): 
                    if ("<returns>" in line): # end of params, begin of returns
                        in_comment +=1
                    elif ("<param name=" not in line) : # param description or bad comment
                        in_comment = 0
                elif (in_comment == 3):
                    if ("</returns>" in line): # end returns
                        in_comment +=1
                elif (in_comment == 4):
                    if ("<example>" in line): # begin example
                        in_comment +=1
                    else : in_comment = 0 # bad comment
                elif (in_comment==5):
                    if ("<code>" in line): # begin code
                        in_comment +=1
                    else : in_comment = 0 # bad comment
                elif (in_comment==6):
                    if ("</code>" in line): # end code
                        in_comment +=1
                elif (in_comment == 7):
                    if ("</example>" in line): # end example -> full documentated function, in_comment = 8
                        in_comment +=1
                    else : in_comment = 0 # bad comment


def testComments(path):
    for line in fileinput.input(path):
        x=0

def cleanData():
    in_comment = 0
    in_function = 0
    functions_documentation.clear()
    input_results.clear()
    functions_variables.clear()

def printResults ():
    flag =0
    
    for key in input_results.keys():
        if (str(input_results.get(key))!='[]') :
            if (flag == 0):
                print('\033[1m' + '---> FUNCTIONS INPUT\'S:' + '\033[0m\n')
            flag+=1
            print("-> Function \033[4m" + key +  "\033[0m:")
            for inp in input_results.get(key)  :
                print('\033[91m\033[1m' + u'\u274C' + '\033[0m  ' + "Missing 'in' in the input parameter \033[93m" + inp + "\033[0m")
    
    if (functions_documentation!={}):
        print('\033[1m' + '\n---> FUNCTIONS DOCUMENTATION:' + '\033[0m\n')
        for key in functions_documentation.keys():
            x = ""
            if (functions_documentation.get(key)==0):
                x = '\033[91m\033[1m' + u'\u274C' + '\033[0m ' + ' '
            else:
                x = '\033[92m\033[1m' + u'\u2714' + '\033[0m ' + ' '
            print(x + key)
    
    if (functions_variables!={}):
        print('\033[1m' + '\n---> VARIABLES NAME RULE:' + '\033[0m\n')
        for key in functions_variables.keys():
            if (functions_variables.get(key)!=[]):
                print("-> Function \033[4m" + key +  "\033[0m:")
                for variable in functions_variables.get(key):
                    x = ""
                    if (variable[2]==0):
                        x = '\033[91m\033[1m' + u'\u274C' + '\033[0m ' + ' '
                    else:
                        x = '\033[92m\033[1m' + u'\u2714' + '\033[0m ' + ' '
                    print(x + variable[0] + ' ' + variable[1] )

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
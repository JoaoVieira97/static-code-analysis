#!/usr/bin/env python3

import fileinput
import sys
import re
import os
from colorama import init
import numpy as np 
init()

# defined data
methods_in_class = 5
lines_in_method = 10
params_in_method = 4
comments_in_method = 0.1 #percentage?

# code data

in_function = 0
classes = {} # class -> [method]
methods = {} # method,class -> lines
input_results = {} # method,class -> [inputs]
comments = {} # method,class -> n_comments 

def readFilesFromPath(path):
  files = []
  files = os.listdir(path)
  return files


def CommentsCount (comments_count,line,comment):
    regexA =  re.search('\/\*.*\*\/',line)     # /* ... */
    regexB = re.search('\/\/.*', line)         # // ...
    regexC = re.search('\/\*.*',line)          # /* ...
    regexEndComment = re.search('.*\*\/',line) # ... */
    if len(comment)==0:
        if regexA:
            comments_count = countCar(comments_count,regexA.group())
        elif regexB:
            comments_count = countCar(comments_count,regexB.group())
        elif regexC:
            comment+= regexC.group()
    elif regexEndComment:
        comment+= regexEndComment.group()
        comments_count = countCar(comments_count,comment)
        comment=""
    else:
        comment+= line
    return comments_count,comment

def countCar (car_count,line):
    regex = re.findall('\S', line)
    if regex:
        car_count+= len(regex)
    return car_count

def regex_keys(in_key,line):
            in_key += line.count('{')
            in_key -= line.count('}')
            keys_instring_regex = re.findall('[\'\"]([^\'\"]*[{}][^\'\"]*)+[\'\"]', line)
            if (keys_instring_regex):
                for st in keys_instring_regex :
                    in_key -= st.count('{')
                    in_key += st.count('}')
            return in_key
def testFile(path, file):
   global in_function

   in_key = 0 # for testing '{' '}' 
   lines = 0
   car_count = 0
   comments_count = 0
   class_name = ""
   comment = ""
   for line in fileinput.input(path):

        class_in_line = re.match(r'\s*(public|private)\s+class+\s+(.+):', line)
        function_in_line = re.match(r'\s*(public|private)\s+(async\s+)?(void|[A-Za-z][A-Za-z0-9\<\>\_?\[\]]*)\s+[A-Z][A-Za-z0-9\_]*\s*\(.*\)', line)
        
        # detect init of class
        if (class_in_line):
            class_name = class_in_line.group(2)
            classes[class_name] = []
        # detect init of function
        elif function_in_line:
            in_function = 1
            comments_count,comment = CommentsCount(comments_count,line,comment)
            car_count = countCar (car_count,line)
            in_key = regex_keys(in_key,line)
            func = re.sub(r'^\s*', r'', function_in_line.group())
            input_results[func,class_name] = []
            methods[func,class_name] = 0
            comments[func,class_name] = 0
            classes[class_name].append(func)
            lines= 1
            # Input names must begin by "in"
            params_search = re.search(r'\(.+\)', func)
            if (params_search):
                params = params_search.group().split(',')
                i = 0

                while(i < len(params)) :
                    params[i] = params[i].replace(r'(','').replace(r')','')
                    input_results[func,class_name].append(params[i])
                    i+=1


        # detect it is inside function
        elif in_function == 1:
            in_key = regex_keys(in_key,line)
            comments_count,comment = CommentsCount(comments_count,line,comment)
            car_count = countCar (car_count,line)
            if ("}" in line  and in_key == 0):
                methods[func,class_name] = lines +1
                in_function = 0
                car_count = 0
                comments[func,class_name] = comments_count
                comments_count = 0
                lines=0
            else :
                lines+=1


def cleanData():
    in_function = 0
    classes.clear()
    methods.clear()
    input_results.clear()
    comments.clear()

def printResults ():  # TODO
    flag = 0
  #  print(input_results)
  #  print(methods)
  #  print(classes)
    print(comments)
    """
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
    
    if (functions_variables):
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
                    """

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
#   $ chmod +x script4.py
#   $ ./script4.py PathToFiles
#      example:
#      $ ./script4.py Files
#  on Windows:
#   $ python ./script4.py PathToFiles
#      example:
#      $ python ./script4.py Files
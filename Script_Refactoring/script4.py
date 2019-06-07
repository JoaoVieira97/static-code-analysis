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
methods_in_class = 5
lines_in_method = 10
params_in_method = 4
comments_in_method = 0.2 #percentage?

# code data
in_function = 0
classes = {} # class -> [method]
methods = {} # method, class -> lines
input_results = {} # method, class -> [inputs]
comments = {} # method, class -> n_comments 

def readFilesFromPath(path):
    files = []
    files = os.listdir(path)
    cs_files = [f for f in files if re.match(r'.+\.cs$', f)]
    return cs_files

def CommentsCount (comments_count, line, comment):
    regexA = re.search('\/\*.*\*\/', line)     # /* ... */
    regexB = re.search('\/\/.*', line)         # // ...
    regexC = re.search('\/\*.*', line)         # /* ...
    regexEndComment = re.search('.*\*\/',line) # ... */
    if (len(comment) == 0):
        if regexA:
            comments_count = countCar(comments_count,regexA.group())
        elif regexB:
            comments_count = countCar(comments_count,regexB.group())
        elif regexC:
            comment += regexC.group()
    elif regexEndComment:
        comment += regexEndComment.group()
        comments_count = countCar(comments_count,comment)
        comment = ""
    else:
        comment += line
    return comments_count,comment

def countCar(car_count, line):
    regex = re.findall('\S', line)
    if regex:
        car_count += len(regex)
    return car_count

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
   global in_function

   in_key = 0 # for testing '{' '}' 
   lines = 0
   car_count = 0
   comments_count = 0
   class_name = ""
   comment = ""
   for line in fileinput.input(path):

        class_in_line = re.match(r'\s*(?:public|private)\s+class+\s+(.+):', line)
        function_in_line = re.match(r'\s*(public|private)\s+(async\s+)?(void|[A-Za-z][A-Za-z0-9\<\>\_?\[\]]*)\s+[A-Z][A-Za-z0-9\_]*\s*\(.*\)', line)
        
        # detect init of class
        if (class_in_line):
            class_name = class_in_line.group(1)
            classes[class_name] = []

        # detect init of function
        elif function_in_line:
            in_function = 1
            comments_count,comment = CommentsCount(comments_count, line, comment)
            car_count += comments_count
            if (re.match(r'\s*(public|private)\s+(async\s+)?(void|[A-Za-z][A-Za-z0-9\<\>\_?\[\]]*)\s+[A-Z][A-Za-z0-9\_]*\s*\(.*\)\s*\{', line)):
                car_count += 1
            in_key = regex_keys(in_key, line)
            func = re.sub(r'^\s*', r'', function_in_line.group())
            input_results[func, class_name] = []
            methods[func, class_name] = 0
            comments[func, class_name] = 0
            classes[class_name].append(func)
            lines = 1
            # get parameters
            params_search = re.search(r'\(.+\)', func)
            if (params_search):
                params = params_search.group().split(',')
                i = 0

                while(i < len(params)) :
                    params[i] = params[i].replace(r'(', '').replace(r')', '')
                    input_results[func, class_name].append(params[i])
                    i+=1

        # detect it is inside function
        elif in_function == 1:
            in_key = regex_keys(in_key, line)
            comments_count,comment = CommentsCount(comments_count, line, comment)
            car_count = countCar(car_count, line)
            if ("}" in line and in_key == 0):
                methods[func, class_name] = lines + 1
                in_function = 0
                car_count -= 2
                if (car_count != 0):
                    div = comments_count / car_count
                    comments[func, class_name] = round(div, 4)
                else: 
                    comments[func, class_name] = 0
                car_count = 0
                comments_count = 0
                lines = 0
            else:
                lines += 1

def cleanData():
    in_function = 0
    classes.clear()
    methods.clear()
    input_results.clear()
    comments.clear()

def printResults():
    good = '\033[92m\033[1m' + u'\u2714' + '\033[0m ' + ' '
    bad = '\033[91m\033[1m' + u'\u274C' + '\033[0m ' + ' '

    # number of classes
    print('\033[1m' + '\n---> CLASSES IMPLEMENTED:' + '\033[0m\n')
    if (len(classes.keys()) == 1):
        print(good + 'Only one class implemented in the file:')
    else:
        print(bad + 'More than one class implemented in the file:')
    for cl in classes.keys():
        print(cl)

    # number of methods
    print('\033[1m' + '\n---> NUMBER OF METHODS IN CLASS: (<= ' + str(methods_in_class)  + ')\033[0m\n')
    for cl in classes.keys():
        if (len(classes[cl]) <= methods_in_class):
            print(good + cl + ' (' + str(len(classes[cl])) + ')')
        else:
            print(bad + cl + ' (' + str(len(classes[cl])) + ')') 

    # method number of lines
    print('\033[1m' + '\n---> NUMBER OF LINES OF METHODS: (<= ' + str(lines_in_method)  + ')\033[0m\n')
    for method in methods.keys():
        if (methods[method] <= lines_in_method):
            print(good + method[1] + ' - ' + method[0] + ' (' + str(methods[method]) + ')')
        else:
            print(bad + method[1] + ' - ' + method[0] + ' (' + str(methods[method]) + ')')

    # method number of parameters
    print('\033[1m' + '\n---> NUMBER OF PARAMETERS OF METHODS: (<= ' + str(params_in_method)  + ')\033[0m\n')
    for method in input_results.keys():
        if (len(input_results[method]) <= params_in_method):
            print(good + method[1] + ' - ' + method[0] + ' (' + str(len(input_results[method])) + ')')
        else:
            print(bad + method[1] + ' - ' + method[0] + ' (' + str(len(input_results[method])) + ')')
    # percentage of comments
    print('\033[1m' + '\n---> PERCENTAGE OF COMMENTS OF METHODS: (<= ' + str(comments_in_method*100) + "%"  + ')\033[0m\n')
    for method in comments.keys():
        if (comments[method] <= comments_in_method):
            print(good + method[1] + ' - ' + method[0] + ' (' + str(comments[method]*100) + '%)')
        else:
            print(bad + method[1] + ' - ' + method[0] + ' (' + str(comments[method]*100) + '%)')

def printResultsGUI(text):
    good = u'\u2714'
    bad =  u'\u274C'

    # number of classes
    text.insert(INSERT, '\n---> CLASSES IMPLEMENTED:\n', ["bold"])
    if (len(classes.keys()) == 1):
        text.insert(INSERT, good, ["green","bold"])
        text.insert(INSERT, ' Only one class implemented in the file:')
    else:
        text.insert(INSERT, bad, ["red","bold"])
        text.insert(INSERT, ' More than one class implemented in the file:')
    for cl in classes.keys():
        text.insert(INSERT, '\n' + cl)

    # number of methods
    text.insert(INSERT, '\n\n---> NUMBER OF METHODS IN CLASS: (<= ' + str(methods_in_class)  + ')\n' , ["bold"])
    for cl in classes.keys():
        if (len(classes[cl]) <= methods_in_class):
            text.insert(INSERT, good, ["green","bold"])
            text.insert(INSERT, ' ' + cl + ' (' + str(len(classes[cl])) + ')\n')
        else:
            text.insert(INSERT, bad, ["red","bold"])
            text.insert(INSERT, ' ' + cl + ' (' + str(len(classes[cl])) + ')\n')

    # method number of lines
    text.insert(INSERT, '\n---> NUMBER OF LINES OF METHODS: (<= ' + str(lines_in_method) + ')\n', ["bold"])
    for method in methods.keys():
        if (methods[method] <= lines_in_method):
            text.insert(INSERT, good, ["green","bold"])
            text.insert(INSERT, ' '+ method[1] + ' - ' + method[0] + ' (' + str(methods[method]) + ')\n')        
        else:
            text.insert(INSERT, bad, ["red","bold"])
            text.insert(INSERT, ' ' + method[1] + ' - ' + method[0] + ' (' + str(methods[method]) + ')\n')


    # method number of parameters
    text.insert(INSERT, '\n---> NUMBER OF PARAMETERS OF METHODS: (<= ' + str(params_in_method)  + ')\n' , ["bold"])
    for method in input_results.keys():
        if (len(input_results[method]) <= params_in_method):
            text.insert(INSERT, good, ["green","bold"])
            text.insert(INSERT, ' ' + method[1] + ' - ' + method[0] + ' (' + str(len(input_results[method])) + ')\n')   
        else:
            text.insert(INSERT, bad, ["red","bold"])
            text.insert(INSERT, ' ' + method[1] + ' - ' + method[0] + ' (' + str(len(input_results[method])) + ')\n')
    # percentage of comments
    text.insert(INSERT, '\n---> PERCENTAGE OF COMMENTS OF METHODS: (<= ' + str(comments_in_method*100) + "%"  + ')\n' ,["bold"] )
    for method in comments.keys():
        if (comments[method] <= comments_in_method):
            text.insert(INSERT, good, ["green","bold"])
            text.insert(INSERT, ' ' + method[1] + ' - ' + method[0] + ' (' + str(comments[method]*100) + '%)\n')   
        else:
            text.insert(INSERT, bad, ["red","bold"])
            text.insert(INSERT, ' ' + method[1] + ' - ' + method[0] + ' (' + str(comments[method]*100) + '%)\n')
    return text

if __name__ == '__main__':
    files = readFilesFromPath(sys.argv[1])
    nfiles = len(files)
    nTested = 0
    print('\033[1m' + '\n--------------------> ' + str(nfiles) + ' FILES TO TEST <--------------------' + '\033[0m')
    while (nTested < nfiles):
        print('\033[34m' + '\033[1m' + '\n-------> ' + '\033[0m' + '\033[34m' + '\033[1m' + '\033[4m' + files[nTested] + '\033[0m' + '\033[34m' + '\033[1m' + ' <-------' + '\033[0m\n')
        testFile(sys.argv[1] + "/" + files[nTested], files[nTested])
        printResults()
        cleanData()
        nTested += 1

def printToGUI(text, path):
    files = readFilesFromPath(path)
    nfiles = len(files)
    nTested = 0
    text.insert(INSERT,'\n--------------------> ' + str(nfiles) + ' FILES TO TEST <--------------------\n', ["center","bold"])
    while (nTested < nfiles):
        text.insert(INSERT, "\n-------> ", ["center","normal","blue"])
        text.insert(INSERT, files[nTested], ["center","underline","blue"])
        text.insert(INSERT, " <-------\n", ["center","normal","blue"])
        testFile(path+ "/" + files[nTested], files[nTested])
        text = printResultsGUI(text)
        cleanData()
        nTested += 1

    return text

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
#!/usr/bin/env python3

import fileinput
import sys
import re
import os
from colorama import init
init()

# defined data

# code data
in_comment = 0
in_function = 0
functions_documentation = {}
input_results = {}
functions_variables = {}
def readFilesFromPath(path):
  files = []
  files = (os.listdir(path))
  return files

def testFile(path,file):
   global in_comment,in_function
   class_name =  file[:len(file)-3]
   for line in fileinput.input(path):
        function_in_line = re.match('\s*(public|private)\s*[a-zA-Z](?!lass)(?!'+ class_name[1:] +').*\(.*\)', line)
        if function_in_line:
            in_function = 1
            func = function_in_line.group()
            input_results.setdefault( func,[])
            functions_variables.setdefault( func,[])
            if (in_comment != 8) :
                functions_documentation.setdefault(func,0)
            else:
                functions_documentation.setdefault(func,1)
                in_comment = 0
            ##Testing input names
            params_search = re.search('\(.+\)',func)
            if (params_search):
                params = params_search.group().split(",")
                i=0
                while(i<len(params)) :
                    params[i] = params[i].replace("(",'').replace(")",'')
                    split_by_space =  re.split("(\s+)",params[i] )
                    input_to_test = split_by_space[len(split_by_space)-1]
                    tested = re.search('^in.*',input_to_test)
                    if not tested :
                        input_results.get(func).append(params[i])
                    i+=1
        elif in_function == 1:
            if ("}" in line and in_comment == 0) : # end of function ????
                in_function = 0
            ##Testing variables names
            variable_test = re.search('(public|private)\s*[^\s]+\s+[A-Za-z]+[^=;\s]*', line)
            if (variable_test):
                    split_text = re.split("(\s+)" ,variable_test.group())
                    t_int = re.search('^int.*',split_text[2]) and re.search('^int.*',split_text[4])
                    t_str = re.search('^string.*',split_text[2]) and re.search('^str.*',split_text[4])
                    t_bln = re.search('^bool.*',split_text[2]) and re.search('^bln.*',split_text[4])
                    t_dt = re.search('^DateTime.*',split_text[2]) and re.search('^dt.*',split_text[4])
                    t_lng = re.search('^long.*',split_text[2]) and re.search('^lng.*',split_text[4])
                    t_lst = re.search('^List.*',split_text[2]) and re.search('^lst.*',split_text[4])
                    t_dic = re.search('^Dictionary.*',split_text[2]) and re.search('^dic.*',split_text[4])
                    t_arr = re.search('^int\[\].*',split_text[2]) and re.search('^arr.*',split_text[4])
                    if(t_int or t_str or t_bln or t_dt or t_lng or t_lst or t_dic or t_arr):
                        split_text.append(1)
                    else:
                        split_text.append(0)
                    functions_variables.setdefault(func, functions_variables.get(func).append(split_text) )

        ## Testing comments        
        elif in_function == 0 and in_comment!=8:
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
            if (flag==0) : print("\033[31m------>Inputs from Functions without in:\033[37m")
            flag+=1
            print("\033[31m--->Function\033[37m"+ key +  " :")
            for inp in input_results.get(key)  :
                print("Missing 'in' in the input parameter \033[31m"+ inp+ " !!!\033[37m")
    if (functions_documentation!={}):
        print("\033[31m------>Well Specificed documentacion of functions:\033[37m")
        for key in functions_documentation.keys():
            x = ""
            if (functions_documentation.get(key)==0):
                x = u'\u274C'
            else:
                x = u'\u2714'
            print(x + key)
    if (functions_variables!={}):
        print("\033[31m------>Variables Names according to rules:\033[37m")
        for key in functions_variables.keys():
            if (functions_variables.get(key)!=[]):
                print("\033[31m--->Function\033[37m"+ key +  " :")
                for variable in functions_variables.get(key):
                    x = ""
                    if (variable[5]==0):
                        x = u'\u274C'
                    else:
                        x = u'\u2714'
                    print(x +  "     " + variable[0] + " " + variable[2] + " " + variable[4])


        
        


files = readFilesFromPath(sys.argv[1])
nfiles = len(files)
nTested = 0
print('\033[1m' + '\n--------------------> ' + str(nfiles) + ' FILES TO TEST:' + '\033[0m')
while nTested<nfiles :
    print('\033[34m' + '\n-----------> ' + files[nTested] + ' :' + '\033[0m\n')
    testFile(sys.argv[1] + "/"+ files[nTested],files[nTested])
    printResults()
    cleanData()
    nTested+=1

# To use this script use :
#  on linux:
#   $ chmod +x script1.py
#   $ ./script1.py PathToFiles
#      example:
#      $ ./script1.py Files
#  on windows:
#   $ python ./script1.py PathToFiles
#      example:
#      $ python ./script1.py Files
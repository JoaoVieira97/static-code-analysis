#!/usr/bin/env python3

import fileinput
import sys
import re
import os
import numpy as np 

in_comment = 0
documentation = ""
d_params = []
d_ok = False

for line in fileinput.input():
    
    is_comment = re.match(r'\s*///\s*(.*)\s*', line)

    function_in_line = re.match(r'\s*(public|private)\s+(async\s+)?(void|[A-Za-z][A-Za-z0-9\<\>\_?\[\]]*)\s+[A-Z][A-Za-z0-9\_]*\s*\(.*\)', line)
    
    if is_comment:
        if (not in_comment):
            in_comment = 1
            documentation = ""
        documentation = documentation + is_comment.groups()[0]
    else:
        if function_in_line:
            func = re.sub(r'^\s*', r'', function_in_line.group())
            params_search = re.search(r'\(.+\)', func)
            if (params_search):
                params = params_search.group().split(',')
            else:
                params = []
            i = 0
            while(i < len(params)) :
                    params[i] = params[i].replace(r'(','').replace(r')','')
                    split_by_space = re.split(r'\s+', params[i])
                    input_to_test = split_by_space[-1]
                    params[i] = input_to_test
                    i = i + 1
            print('\n' + func + '')
            if (documentation != ""):
                print("has documentation:")
                if (not d_ok):
                    print(" Documentation is not ok")
                else:
                    print(" Structure of documentation is ok")
                    print('     Function params = ' + str(params))
                    print('     Documentation params = ' + str(d_params))
                    equals = np.array_equal(params, d_params)
                    if (equals):
                        print(' Params are fine!')
                    else:
                        print(' Params are wrong!')
            else:
                print("no documentation")
            documentation = ""
            d_params = []

        else:
            if in_comment:
                in_comment = 0
                correct_documentation = re.match(r'<summary>[^<]+</summary>((?:<param name="[^\"]+">[^<]+</param>)*)<returns>[^<]+</returns><example><code>[^<]+</code></example>', documentation)
                if (correct_documentation):
                    #print('ok')
                    d_ok = True
                    params = correct_documentation.groups()[0]
                    d_params = re.findall(r'<param name="([^\"]+)">[^<]+</param>', params)
                    #print('params = ' + str(d_params))
                else: 
                    #print('not ok')
                    d_ok = False
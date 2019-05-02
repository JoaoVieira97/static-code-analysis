#!/usr/bin/env python3

import fileinput
import sys
import re

# defined data
table_init = 'tb'
required_fields = {
    'ID': 0,
    'Sistema': 0,
    'Ativo': 0, 
    'DataCriacao': 0,
    'UtilizadorCriacao': 0, 
    'DataAlteracao': 0, 
    'UtilizadorAlteracao': 0,
    'F3MMarcador': 0
}
fk_init = 'ID'
properties_max_length = 20

# code data
step = 0
tableName_rule = False
fk_n = 0
foreignKeys_wrong = []
prop_n = 0
properties_wrong = []

for line in fileinput.input():
    
    if (step == 0): # find table name
        
        # table name
        table_name = re.match(r'\s*\[Table\(\"(\w*)\"\)\]\s*', line)
        
        if (table_name):
            step = 1
            table = table_name.groups()[0]
            if (table[0:2] == table_init):
                tableName_rule = True

    elif (step == 1): # find required fields, foreign keys and size of properties

        # required fields
        field_name = re.match(r'\s*\[Column\(\"(\w*)\"\)\]\s*', line)

        if (field_name):
            field = field_name.groups()[0]
            if (field in required_fields):
                required_fields[field] = 1

        # foreign keys
        foreign_key = re.match(r'\s*\[ForeignKey\(\"(\w*)\"\)\]\s*', line)

        if (foreign_key):
            fk_n += 1
            fk = foreign_key.groups()[0]
            if (fk[0:2] != fk_init):
                foreignKeys_wrong.append(fk)

        # properties size
        property = re.match(r'\s*(private|public|protected|internal|protected internal|private protected)(\s*(virtual|override))?\s*[A-Za-z\<\>?\[\]]+\s*(\w+)\s*\{\s*get\s*;\s*set\s*;\s*\}\s*', line)
        
        if (property):
            prop_n += 1
            prop = property.groups()[-1]
            if (len(prop) > properties_max_length):
                properties_wrong.append(prop)

if (step == 0):
    
    print('\033[91m' + '\033[1m' + 'Error: ' + '\033[0m' + 'No table name defined in the file processed!')

else:

    print('\033[1m' + '---> TABLE NAME RULES:' + '\033[0m')
    if (tableName_rule):
        print('\033[92m\033[1m' + u'\u2714' + '\033[0m ' + '\033[4m' + table + '\033[0m matches the rule!')
    else:
        print('\033[91m\033[1m' + u'\u274C' + '\033[0m ' + '\033[4m' + table + '\033[0m doesn\'t match the rule!')

    print('\033[1m' + '\n---> REQUIRED FIELDS:' + '\033[0m')
    for field in required_fields:
        if (required_fields[field] == 1):
            print('\033[92m\033[1m' + u'\u2714' + '\033[0m ' + field)
        else:
            print('\033[91m\033[1m' + u'\u274C' + '\033[0m ' + field)

    print('\033[1m' + '\n---> FOREIGN KEYS RULE:' + '\033[0m')
    if (foreignKeys_wrong == []):
        print('\033[92m\033[1m' + u'\u2714' + '\033[0m ' + 'All the ' + '\033[1m' + str(fk_n) + '\033[0m' + ' foreign keys are well defined!')
    else:
        print('\033[91m\033[1m' + u'\u274C' + '\033[0m ' + 'The following ' + '\033[1m' + str(len(foreignKeys_wrong)) + '\033[0m' + ' foreign keys didn\'t match the rule!')
        print('\n'.join(foreignKeys_wrong))

    print('\033[1m' + '\n---> PROPERTIES SIZE:' + '\033[0m')
    if (properties_wrong == []):
        print('\033[92m\033[1m' + u'\u2714' + '\033[0m ' + 'All the ' + '\033[1m' + str(prop_n) + '\033[0m' + ' properties have a proper size! (<= 20 char\'s)')
    else:
        print('\033[91m\033[1m' + u'\u274C' + '\033[0m ' + 'The following ' + '\033[1m' + str(len(properties_wrong)) + '\033[0m' + ' properties didn\'t match the rule! (<= 20 char\'s)')
        print('\n'.join(properties_wrong))

# To use this script use :
#  $ chmod +x script1.py
#  $ ./script1.py C#DataFile
#     example:
#     $ ./script1.py TbArtigos.cs 
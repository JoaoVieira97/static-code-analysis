#!/usr/bin/env python3

import fileinput
import re
import sys
import os
from colorama import init
init()

# readable info
tables = []
models = []
reps = []
controllers = []

# missing files
models_m = []
reps_m = []
controllers_m = []

def readTables():
    global tables
    for line in fileinput.input(files=sys.argv[1]):
        if ("public" in line and "virtual" in line and "DbSet" in line and "get" in line and "set" in line):
            splitLine = re.split(r'\s+', line)
            tables.append(splitLine[4])

def readFilesFromPath(path):
  files = []
  files = (os.listdir(path))
  return files

def readAll():
  global tables
  global models
  global reps
  global controllers
  
  readTables()
  print('\033[4m' + '\033[1m' + '---> TABLES:' + '\033[0m')
  print('\n'.join(tables))

  models = readFilesFromPath(sys.argv[2])
  print('\033[1m' + '\n---> MODELS:' + '\033[0m')
  print('\n'.join(models))

  reps = readFilesFromPath(sys.argv[3])
  print('\033[1m' + '\n---> REPOSITORIES:' + '\033[0m')
  print('\n'.join(reps))
  
  controllers = readFilesFromPath(sys.argv[4])
  print('\033[1m' + '\n--> CONTROLLERS:' + '\033[0m')
  print('\n'.join(controllers))

# i = 1 -> models
# i = 2 -> reps
# i = 3 -> controllers
def testDirectory(i):
  missing = len(tables)
  
  aux = []
  if (i == 1): aux = models
  elif (i == 2): aux = reps
  else: aux = controllers

  for t in tables:
    exist = False
    for a in aux:
      if (i == 1): t_withcs = t[2:] + ".cs" # TbClient = Client.cs to compare with model
      elif (i == 2): t_withcs = "Repositorio" + t[2:] + ".cs" # TbClient = RepositorioClient.cs to compare with Repository
      else: t_withcs = t[2:] + "Controller.cs" # TbClient = ClientController.cs to compare with Controller
      if (t_withcs == a):
        missing -= 1
        exist = True
    if (exist == False):
      if (i == 1): models_m.append(t)
      elif (i == 2): reps_m.append(t)
      else: controllers_m.append(t)
  
  return missing

def testAll():
  print('\033[91m' + '\033[1m' + '\n--> RESULTS:' + '\033[0m')
  
  modelsMissing = testDirectory(1)
  print("Missing " + str(modelsMissing) + " from " + str(len(tables)) + " models according to tables!")
  #print('\n'.join(models_m))

  repsMissing = testDirectory(2)
  print("Missing " + str(repsMissing) + " from " + str(len(tables)) + " repositorys according to tables!")
  #print('\n'.join(reps_m))

  controllersMissing = testDirectory(3)
  print("Missing " + str(controllersMissing) + " from " + str(len(tables)) + " controllers according to tables!")
  #print('\n'.join(controllers_m))

readAll()
testAll()

# To use this script use :
#  on linux:
#   $ chmod +x script2.py
#   $ ./script2.py TablesContextFile ModelsPath RepositorysPath ControllersPath
#      example:
#      $ ./script2.py F3MESR3S1Context.cs Models Reps Controllers
#  on windows:
#   $ python ./script2.py TablesContextFile ModelsPath RepositorysPath ControllersPath
#      example:
#      $ python ./script2.py F3MESR3S1Context.cs Models Reps Controllers
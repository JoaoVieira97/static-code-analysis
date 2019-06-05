#!/usr/bin/env python3

from tkinter import *
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
modelsMissing = 0
repsMissing = 0
controllersMissing = 0

def readTables(file_path):
    global tables
    for line in fileinput.input(files=file_path):
        if ("public" in line and "virtual" in line and "DbSet" in line and "get" in line and "set" in line):
            splitLine = re.split(r'\s+', line)
            tables.append(splitLine[4])

def readFilesFromPath(path):
  files = []
  files = (os.listdir(path))
  return files

def readAll(file_path, models_path, reps_path, controllers_path):
  global tables
  global models
  global reps
  global controllers  
  
  readTables(file_path)

  models = readFilesFromPath(models_path)
  reps = readFilesFromPath(reps_path)
  controllers = readFilesFromPath(controllers_path)

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
  global modelsMissing
  global repsMissing
  global controllersMissing
  
  modelsMissing = testDirectory(1)
  repsMissing = testDirectory(2)
  controllersMissing = testDirectory(3)

def printResults():
  global tables
  global models
  global reps
  global controllers

  good = '\033[92m\033[1m' + u'\u2714' + '\033[0m ' + ' '
  bad = '\033[91m\033[1m' + u'\u274C' + '\033[0m ' + ' '

  # Data
  print('\033[1m' + '---> TABLES:' + '\033[0m')
  print('\n'.join(tables))

  print('\033[1m' + '\n---> MODELS:' + '\033[0m')
  print('\n'.join(models))

  print('\033[1m' + '\n---> REPOSITORIES:' + '\033[0m')
  print('\n'.join(reps))

  print('\033[1m' + '\n---> CONTROLLERS:' + '\033[0m')
  print('\n'.join(controllers))

  # Results
  print('\033[91m' + '\033[1m' + '\n--> RESULTS:' + '\033[0m')
  
  if (modelsMissing == 0):
    print(good + "Missing " + str(modelsMissing) + " from " + str(len(tables)) + " models according to tables!")
  else:
    print(bad + "Missing " + str(modelsMissing) + " from " + str(len(tables)) + " models according to tables!")

  if (repsMissing == 0):
    print(good + "Missing " + str(repsMissing) + " from " + str(len(tables)) + " repositorys according to tables!")
  else:
    print(bad + "Missing " + str(repsMissing) + " from " + str(len(tables)) + " repositorys according to tables!")
  
  if (controllersMissing == 0):
    print(good + "Missing " + str(controllersMissing) + " from " + str(len(tables)) + " controllers according to tables!")
  else:
    print(bad + "Missing " + str(controllersMissing) + " from " + str(len(tables)) + " controllers according to tables!")

def printResultsToGUI(text):
  global tables
  global models
  global reps
  global controllers

  good = u'\u2714'
  bad = u'\u274C'

  # Data
  text.insert(INSERT, '---> TABLES:\n', ["bold"])
  text.insert(INSERT, '\n'.join(tables))

  text.insert(INSERT, '\n\n---> MODELS:\n', ["bold"])
  text.insert(INSERT, '\n'.join(models))

  text.insert(INSERT, '\n\n---> REPOSITORIES:\n', ["bold"])
  text.insert(INSERT, '\n'.join(reps))

  text.insert(INSERT, '\n\n---> CONTROLLERS:\n', ["bold"])
  text.insert(INSERT, '\n'.join(controllers))

  # Results
  text.insert(INSERT, '\n\n--> RESULTS:\n', ["red","bold"])
  
  if (modelsMissing == 0):
    text.insert(INSERT, good, ["green","bold"])
    text.insert(INSERT, " Missing " + str(modelsMissing) + " from " + str(len(tables)) + " models according to tables!\n")
  else:
    text.insert(INSERT, bad, ["red","bold"])
    text.insert(INSERT, " Missing " + str(modelsMissing) + " from " + str(len(tables)) + " models according to tables!\n")

  if (repsMissing == 0):
    text.insert(INSERT, good, ["green","bold"])
    text.insert(INSERT, " Missing " + str(repsMissing) + " from " + str(len(tables)) + " repositorys according to tables!\n")
  else:
    text.insert(INSERT, bad, ["red","bold"])
    text.insert(INSERT, " Missing " + str(repsMissing) + " from " + str(len(tables)) + " repositorys according to tables!\n")
  
  if (controllersMissing == 0):
    text.insert(INSERT, good, ["green","bold"])
    text.insert(INSERT, " Missing " + str(controllersMissing) + " from " + str(len(tables)) + " controllers according to tables!\n")
  else:
    text.insert(INSERT, bad, ["red","bold"])
    text.insert(INSERT, " Missing " + str(controllersMissing) + " from " + str(len(tables)) + " controllers according to tables!\n")
  
  return text

if __name__ == '__main__':
  readAll(sys.argv[1], sys.argv[2], sys.argv[3], sys.argv[4])
  testAll()
  printResults()

def printToGUI (text, file_path, models_path, reps_path, controllers_path):
  readAll(file_path, models_path, reps_path, controllers_path)
  testAll()
  text = printResultsToGUI(text)
  return text

# To use this script use :
#  on Linux:
#   $ chmod +x script2.py
#   $ ./script2.py TablesContextFile ModelsPath RepositorysPath ControllersPath
#      example:
#      $ ./script2.py F3MESR3S1Context.cs Models Reps Controllers
#  on Windows:
#   $ python ./script2.py TablesContextFile ModelsPath RepositorysPath ControllersPath
#      example:
#      $ python ./script2.py F3MESR3S1Context.cs Models Reps Controllers
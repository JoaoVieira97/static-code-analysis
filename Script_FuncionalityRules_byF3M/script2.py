import fileinput
import re
import sys
import os

tables = []
models = []
reps = []
controllers = []
def readTables():
    tables = []
    for line in fileinput.input(files=sys.argv[1]):
        if ("public" in line and "virtual" in line and "DbSet" in line and "get" in line and "set" in line):
            splitLine = re.split(r'\s+', line)
            tables.append(splitLine[4])
    return tables

def readFilesFromPath(path):
  models = []
  modelsPath = path
  models = (os.listdir(modelsPath))
  return models

def readAll():
  global tables
  global models
  global reps
  global controllers 
  tables = readTables()
  print("Tables :" + str(tables))
  models = readFilesFromPath(sys.argv[2])
  print("Models :" + str(models))
  reps = readFilesFromPath(sys.argv[3])
  print("Reps :" + str(reps))
  controllers = readFilesFromPath(sys.argv[4])
  print("Controllers :" + str(controllers))


def testModels():
  missing = len(tables)
  for t in tables :
    for m in models :
      t_withcs = t[2:]+".cs" # TbClient = Client.cs to compare with model
      if( t_withcs == m) :
        missing-=1
  return missing

def testReps():
  missing = len(tables)
  for t in tables :
    for r in reps :
      t_withcs = "Repositorio" + t[2:] + ".cs"  # TbClient = RepositorioClient.cs to compare with Repository
      if( t_withcs == r) :
        missing-=1
  return missing

def testControllers():
  missing = len(tables)
  for t in tables :
    for c in controllers :
      t_withcs = t[2:]+"Controller.cs"  # TbClient = ClientController.cs to compare with Controller
      if( t_withcs == c) :
        missing-=1
  return missing

def testAll():
  modelsMissing = testModels()
  print("Missing "+ str(modelsMissing) +" from " + str(len(tables)) + " models according to tables!")
  repsMissing = testReps()
  print("Missing "+ str(repsMissing) +" from " + str(len(tables)) + " repositorys according to tables!")
  controllersMissing = testControllers()
  print("Missing "+ str(controllersMissing) +" from " + str(len(tables)) + " controllers according to tables!")

readAll()
testAll()

# To test this script use : 
#   py script2.py TablesContextFile ModelsPath RepositorysPath ControllersPath
#   example:
#     py script2.py  F3MESR3S1Context.cs './Models' './Reps' './Controllers'
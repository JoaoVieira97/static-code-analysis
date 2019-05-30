from tkinter import *
from tkinter import filedialog
import subprocess
import os
from os import system as cmd
import sys
sys.path.append('./../')
from Script_TablesCreationRules_byF3M.script1 import printToGUI as print1
from Script_FuncionalityRules_byF3M.script2 import printToGUI as print2
from Script_ServerRules_byF3M.script3 import printToGUI as print3
from Script_Refactoring.script4 import printToGUI as print4

WINDOW_SIZE = "1000x1000"

root = Tk()
root.title("Static code analysis")

if (os.name == 'nt'):
   root.state('zoomed')
else:
   root.attributes('-zoomed', True)

def execute(script_number):
   global folder_path
   global text
   text.delete('1.0', END)
   folder = filedialog.askdirectory()
   folder_path = folder
   print(folder)
   if (script_number == 1):
      text = print1(text, folder)
   elif (script_number == 3):
      text = print3(text, folder)
   elif (script_number == 4):
      text = print4(text, folder)

def execute_funcionality():
   global folder_path
   global text
   text.delete('1.0', END)
   folder_file = filedialog.askopenfilename(title='ESCOLHA O FICHEIRO DE CONTEXTO DAS TABELAS')
   #folder_path.set(folder_file)
   folder_models = filedialog.askdirectory(title='ESCOLHA A PASTA QUE CONTÊM OS MODELOS')
   folder_reps = filedialog.askdirectory(title='ESCOLHA A PASTA QUE CONTÊM OS REPOSITÓRIOS')
   folder_controllers = filedialog.askdirectory(title='ESCOLHA A PASTA QUE CONTÊM OS CONTROLADORES')
   print(folder_file)
   print(folder_models)
   print(folder_reps)
   print(folder_controllers)
   text = print2(text, folder_file, folder_models, folder_reps, folder_controllers)

folder_path = ''

frame = Frame(root)
frame.pack()

button_1 = Button(frame, text ="Tables creation rules script", font = ("Calibri", "12"), width = 22, height = 2, command = lambda: execute(1))
button_1.pack(side = LEFT)

button_2 = Button(frame, text ="Funcionality rules", font = ("Calibri", "12"), width = 22, height = 2, command = execute_funcionality)
button_2.pack(side = LEFT)

button_3 = Button(frame, text ="Server rules script", font = ("Calibri", "12"), width = 22, height = 2, command = lambda: execute(3))
button_3.pack(side = LEFT)

button_4 = Button(frame, text ="Refactoring script", font = ("Calibri", "12"), width = 22, height = 2, command = lambda: execute(4))
button_4.pack(side = LEFT)

frame_text = Frame(root)
frame_text.pack(side = BOTTOM)

text = Text(frame_text, background="black")

text.tag_config("red", foreground="red")
text.tag_config("green", foreground="green")
text.tag_config("white", foreground="white")
text.tag_config("blue",foreground="blue")
text.tag_config("bold", font=("Ubuntu","12","bold"))
text.tag_config("underline", font=("Ubuntu","12","underline"))
text.tag_config("normal", font=("Ubuntu","12"))
text.tag_config("center", justify="center")
text.tag_config("font", font=("Ubuntu","12"))

text.tag_add("font","1.0","end")

text.pack()

root.mainloop()
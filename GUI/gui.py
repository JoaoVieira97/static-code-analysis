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

# FOLDERS FOR SCRIPTS
s1_folder = ''
s2_context = ''
s2_models = ''
s2_repos = ''
s2_controllers = ''
s3_folder = ''
s4_folder = ''
# -------------------

root = Tk()
root.title("Static code analysis")

if (os.name == 'nt'):
   root.state('zoomed')
else:
   root.attributes('-zoomed', True)

def execute(script_number):
   global text
   global s1_folder
   global s2_context
   global s2_models
   global s2_repos
   global s2_controllers
   global s3_folder
   global s4_folder
   text.delete('1.0', END)
   if (script_number == 1):
      if (not s1_folder):
         text.insert(INSERT, 'Selecione a pasta necessária', ["red","bold"])
         return
      text = print1(text, s1_folder)
   elif (script_number == 2):
      if (not s2_context or not s2_models or not s2_repos or not s2_controllers):
         text.insert(INSERT, 'Selecione o ficheiro e as pastas necessária', ["red","bold"])
         return
      text = print2(text, s2_context, s2_models, s2_repos, s2_controllers)
   elif (script_number == 3):
      if (not s3_folder):
         text.insert(INSERT, 'Selecione a pasta necessária', ["red","bold"])
         return
      text = print3(text, s3_folder)
   else:
      if (not s4_folder):
         text.insert(INSERT, 'Selecione a pasta necessária', ["red","bold"])
         return
      text = print4(text, s4_folder)

def browse(script_number):
   global text
   global s1_folder
   global s2_context
   global s2_models
   global s2_repos
   global s2_controllers
   global s3_folder
   global s4_folder
   text.delete('1.0', END)
   if (script_number == 1 or script_number == 3 or script_number == 4):
      folder = filedialog.askdirectory(title='ESCOLHA A PASTA')
      if (folder):
         if (script_number == 1):
            s1_folder = folder
            s1_1f["text"] = s1_folder
            s1_1f["fg"] = "#008000"
         elif (script_number == 3):
            s3_folder = folder
            s3_1f["text"] = s3_folder
            s3_1f["fg"] = "#008000"
         else:
            s4_folder = folder
            s4_1f["text"] = s4_folder
            s4_1f["fg"] = "#008000"
   else:
      context = filedialog.askopenfilename(title='ESCOLHA O FICHEIRO DE CONTEXTO DAS TABELAS')
      if (context):
         s2_context = context
         s2_1f["text"] = s2_context
         s2_1f["fg"] = "#008000"
      folder = filedialog.askdirectory(title='ESCOLHA A PASTA QUE CONTÊM OS MODELOS')
      if (folder):
         s2_models = folder
         s2_2f["text"] = s2_models
         s2_2f["fg"] = "#008000"
      folder = filedialog.askdirectory(title='ESCOLHA A PASTA QUE CONTÊM OS REPOSITÓRIOS')
      if (folder):
         s2_repos = folder
         s2_3f["text"] = s2_repos
         s2_3f["fg"] = "#008000"
      folder = filedialog.askdirectory(title='ESCOLHA A PASTA QUE CONTÊM OS CONTROLADORES')
      if (folder):
         s2_controllers = folder
         s2_4f["text"] = s2_controllers
         s2_4f["fg"] = "#008000"

# ---------------------------------------------------------
# BUTTONS FRAME
# ---------------------------------------------------------

frame_buttons = Frame(root, relief='flat', borderwidth=20)
frame_buttons.pack()

button_1 = Button(frame_buttons, text ="Criação de tabelas", font = ("Calibri", "12"), width = 22, height = 2, borderwidth = 6, highlightbackground="#ffa502", highlightthickness=2, command = lambda: execute(1))
button_1.grid(column=0, row=0, padx=100)

button_2 = Button(frame_buttons, text ="Regras de funcionalidades", font = ("Calibri", "12"), width = 22, height = 2, borderwidth = 6, highlightbackground="#ffa502", highlightthickness=2,  command = lambda: execute(2))
button_2.grid(column=1, row=0, padx=100)

button_3 = Button(frame_buttons, text ="Regras de servidor", font = ("Calibri", "12"), width = 22, height = 2, borderwidth = 6, highlightbackground="#ffa502", highlightthickness=2, command = lambda: execute(3))
button_3.grid(column=2, row=0, padx=100)

button_4 = Button(frame_buttons, text ="Regras de refactoring", font = ("Calibri", "12"), width = 22, height = 2, borderwidth = 6, highlightbackground="#ffa502", highlightthickness=2, command = lambda: execute(4))
button_4.grid(column=3, row=0, padx=100)

# ---------------------------------------------------------
# PATH'S FRAME
# ---------------------------------------------------------

frame_paths = Frame(root, relief='flat', borderwidth=20)

# Script 1

frame_1 = Frame(frame_paths, background="#C8C8C8", borderwidth = 6)

browse_1 = Button(frame_1, text ="Browse", font = ("Calibri", "10"), borderwidth = 4, command = lambda: browse(1))
browse_1.grid(sticky = W, column=0, row=0, pady=10)

s1_1 = Label(frame_1, text="* Pasta de tabelas:", font = ("Calibri", "12", "bold"))
s1_1.grid(sticky = W, column=0, row=1)

s1_1f = Label(frame_1, text="não selecionado", font = ("Calibri", "12"), fg="#cc0000")
s1_1f.grid(sticky = W, column=0, row=2)

frame_1.grid(column=0, row=0, sticky='nsew', padx=10)

# Script 2

frame_2 = Frame(frame_paths, background="#C8C8C8", borderwidth = 6)

browse_2 = Button(frame_2, text ="Browse", font = ("Calibri", "10"), borderwidth = 4, command = lambda: browse(2))
browse_2.grid(sticky = W, column=0, row=0, pady=10)

s2_1 = Label(frame_2, text="* Ficheiro de contexto de tabelas:", font = ("Calibri", "12", "bold"))
s2_1.grid(sticky = W, column=0, row=1)

s2_1f = Label(frame_2, text="não selecionado", font = ("Calibri", "12"), fg="#cc0000")
s2_1f.grid(sticky = W, column=0, row=2)

s2_2 = Label(frame_2, text="* Pasta de modelos:", font = ("Calibri", "12", "bold"))
s2_2.grid(sticky = W, column=0, row=3)

s2_2f = Label(frame_2, text="não selecionado", font = ("Calibri", "12"), fg="#cc0000")
s2_2f.grid(sticky = W, column=0, row=4)

s2_3 = Label(frame_2, text="* Pasta de repositórios:", font = ("Calibri", "12", "bold"))
s2_3.grid(sticky = W, column=0, row=5)

s2_3f = Label(frame_2, text="não selecionado", font = ("Calibri", "12"), fg="#cc0000")
s2_3f.grid(sticky = W, column=0, row=6)

s2_4 = Label(frame_2, text="* Pasta de controladores:", font = ("Calibri", "12", "bold"))
s2_4.grid(sticky = W, column=0, row=7)

s2_4f = Label(frame_2, text="não selecionado", font = ("Calibri", "12"), fg="#cc0000")
s2_4f.grid(sticky = W, column=0, row=8)

frame_2.grid(column=1, row=0, sticky="nsew", padx=10)

# Script 3

frame_3 = Frame(frame_paths, background="#C8C8C8", borderwidth = 6)

browse_3 = Button(frame_3, text ="Browse", font = ("Calibri", "10"), borderwidth = 4, command = lambda: browse(3))
browse_3.grid(sticky = W, column=0, row=0, pady=10)

s3_1 = Label(frame_3, text="* Pasta de ficheiros:", font = ("Calibri", "12", "bold"))
s3_1.grid(sticky = W, column=0, row=1)

s3_1f = Label(frame_3, text="não selecionado", font = ("Calibri", "12"), fg="#cc0000")
s3_1f.grid(sticky = W, column=0, row=2)

frame_3.grid(column=2, row=0, sticky="nsew", padx=10)

# Script 4

frame_4 = Frame(frame_paths, background="#C8C8C8", borderwidth = 6)

browse_4 = Button(frame_4, text ="Browse", font = ("Calibri", "10"), borderwidth = 4, command = lambda: browse(4))
browse_4.grid(sticky = W, column=0, row=0, pady=10)

s4_1 = Label(frame_4, text="* Pasta de ficheiros:", font = ("Calibri", "12", "bold"))
s4_1.grid(sticky = W, column=0, row=1)

s4_1f = Label(frame_4, text="não selecionado", font = ("Calibri", "12"), fg="#cc0000")
s4_1f.grid(sticky = W, column=0, row=2)

frame_4.grid(column=3, row=0, sticky="nsew", padx=10)

# Uniform size por the 4 frames

frame_paths.grid_columnconfigure(0, weight=1, uniform="group1",minsize=470)
frame_paths.grid_columnconfigure(1, weight=1, uniform="group1",minsize=470)
frame_paths.grid_columnconfigure(2, weight=1, uniform="group1",minsize=470)
frame_paths.grid_columnconfigure(3, weight=1, uniform="group1",minsize=470)
frame_paths.grid_rowconfigure(0, weight=1)

frame_paths.pack()

# ---------------------------------------------------------
# TEXT FRAME
# ---------------------------------------------------------

frame_text = Frame(root, relief='flat', borderwidth=20)
frame_text.pack()

text = Text(frame_text, background="#1e272e", height=1000, width=1000, borderwidth=10, padx=20, pady=20, highlightbackground="#ffa502", highlightthickness=3)

text.tag_config("red", foreground="red")
text.tag_config("green", foreground="green")
text.tag_config("white", foreground="white")
text.tag_config("blue",foreground="blue")
text.tag_config("yellow",foreground="yellow")
text.tag_config("orange",foreground="orange")
text.tag_config("bold", font=("Calibri","12","bold"))
text.tag_config("underline", font=("Calibri","12","underline"))
text.tag_config("normal", font=("Calibri","12"))
text.tag_config("center", justify="center")
text.tag_config("font", font=("Calibri","12"))

text.tag_add("font","1.0","end")

text.insert(INSERT, 'Bem-vindo! Comece a testar.', ["orange","bold"])

text.pack()

# ---------------------------------------------------------
# MENU BAR
# ---------------------------------------------------------

def clean():
   global text
   global s1_folder
   global s2_context
   global s2_models
   global s2_repos
   global s2_controllers
   global s3_folder
   global s4_folder
   text.delete('1.0', END)
   s1_folder = ''
   s1_1f.configure(text="não selecionado", fg="#cc0000")
   s2_context = ''
   s2_1f.configure(text="não selecionado", fg="#cc0000")
   s2_models = ''
   s2_2f.configure(text="não selecionado", fg="#cc0000")
   s2_repos = ''
   s2_3f.configure(text="não selecionado", fg="#cc0000")
   s2_controllers = ''
   s2_4f.configure(text="não selecionado", fg="#cc0000")
   s3_folder = ''
   s3_1f.configure(text="não selecionado", fg="#cc0000")
   s4_folder = ''
   s4_1f.configure(text="não selecionado", fg="#cc0000")
   
menubar = Menu(root)
menubar.add_command(label="LIMPAR TUDO", command=clean)

root.config(menu=menubar)

# ---------------------------------------------------------

root.mainloop()
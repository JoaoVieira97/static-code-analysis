from tkinter import filedialog
from tkinter import *
import subprocess
import os
from os import system as cmd

WINDOW_SIZE = "1000x1000"
root = Tk()
root.geometry(WINDOW_SIZE)

def button1():
   print("Butão 1")
   subprocess.call('ls', shell=True)
def button2():
   print("Butão 2")
   subprocess.call('cat odoo', shell=True)


button_test  = Button(root, text ="Butão 1", command = button1)
button_test.pack()

button_2_test  = Button(root, text ="Butão", command = button2)
button_2_test.pack()

termf = Frame(root, height=500, width=1000)

termf.pack(fill=BOTH, expand=YES)
wid = termf.winfo_id()

os.system('xterm -fa \'Monospace\' -fs 12 -into %d -geometry 100x20 -sb &' % wid)

def send_entry_to_terminal(*args):
    cmd("%s" % (button1))

root.mainloop()
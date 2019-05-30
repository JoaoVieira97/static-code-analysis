from tkinter import filedialog
from tkinter import *

WINDOW_SIZE = "200x200"

def browse_button():
    global folder_path
    filename = filedialog.askdirectory()
    folder_path.set(filename)
    print(filename)

root = Tk()
root.geometry(WINDOW_SIZE)

folder_path = StringVar()
lbl1 = Label(master=root,textvariable=folder_path)
lbl1.grid(row=0, column=1)
button = Button(text="Procurar pasta", command=browse_button)
button.grid(row=0, column=3)

mainloop()
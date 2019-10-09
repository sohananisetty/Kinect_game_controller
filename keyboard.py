import ctypes
import time
import sys

Key1 = sys.argv[1]
Key2 = sys.argv[2]
SendInput = ctypes.windll.user32.SendInput

if Key1 =='W' :
    Key1 = 0x11
elif Key1 == 'A':
    Key1 = 0x1E
elif Key1 == "S":
    Key1 = 0x39
elif Key1 == "D":
    Key1 = 0x20
elif Key1 =="space":
	Key1 ==0x39
elif Key1 == "shift":
	Key1 = 0x36


if Key2 =='W' :
    Key2 = 0x11
elif Key2 == 'A':
    Key2 = 0x1E
elif Key2 == "S":
    Key2 = 0x39
elif Key2 == "D":
    Key2 = 0x20
elif Key2 =="space":
	Key2 ==0x39
elif Key2 == "shift":
	Key2 = 0x36

# C struct redefinitions
PUL = ctypes.POINTER(ctypes.c_ulong)
class KeyBdInput(ctypes.Structure):
    _fields_ = [("wVk", ctypes.c_ushort),
                ("wScan", ctypes.c_ushort),
                ("dwFlags", ctypes.c_ulong),
                ("time", ctypes.c_ulong),
                ("dwExtraInfo", PUL)]

class HardwareInput(ctypes.Structure):
    _fields_ = [("uMsg", ctypes.c_ulong),
                ("wParamL", ctypes.c_short),
                ("wParamH", ctypes.c_ushort)]

class MouseInput(ctypes.Structure):
    _fields_ = [("dx", ctypes.c_long),
                ("dy", ctypes.c_long),
                ("mouseData", ctypes.c_ulong),
                ("dwFlags", ctypes.c_ulong),
                ("time",ctypes.c_ulong),
                ("dwExtraInfo", PUL)]

class Input_I(ctypes.Union):
    _fields_ = [("ki", KeyBdInput),
                 ("mi", MouseInput),
                 ("hi", HardwareInput)]

class Input(ctypes.Structure):
    _fields_ = [("type", ctypes.c_ulong),
                ("ii", Input_I)]

# Actuals Functions

def PressKey(hexKeyCode):
    extra = ctypes.c_ulong(0)
    ii_ = Input_I()
    ii_.ki = KeyBdInput( 0, hexKeyCode, 0x0008, 0, ctypes.pointer(extra) )
    x = Input( ctypes.c_ulong(1), ii_ )
    ctypes.windll.user32.SendInput(1, ctypes.pointer(x), ctypes.sizeof(x))

def ReleaseKey(hexKeyCode):
    extra = ctypes.c_ulong(0)
    ii_ = Input_I()
    ii_.ki = KeyBdInput( 0, hexKeyCode, 0x0008 | 0x0002, 0, ctypes.pointer(extra) )
    x = Input( ctypes.c_ulong(1), ii_ )
    ctypes.windll.user32.SendInput(1, ctypes.pointer(x), ctypes.sizeof(x))

if __name__ == '__main__':
    PressKey(Key1)
   #PressKey(Key2)
    time.sleep(1)
    ReleaseKey(Key1)
    #ReleaseKey(Key2)
    time.sleep(1)
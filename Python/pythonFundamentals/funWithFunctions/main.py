"""Odd/Even"""

def oddEven():
    evod = ""
    for i in range(1,2001):
        if i % 2 == 0:
            evod = "even"
        else:
            evod = "odd"
        print("Number is {}. This is an {} number.").format(i,evod)
oddEven()

""""""""""""""""""""""""""""""""""""""""""""""""""
"""Multiply"""
a = [2,4,10,16]
def multiply(arr, b):
    for i , k in enumerate(arr):
        arr[i] *= b
    return arr

b = multiply(a, 5)
print b

""""""""""""""""""""""""""""""""""""""
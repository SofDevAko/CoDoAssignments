"""Multiples"""
"""Part 1"""
for i in range(1000):
    if not(i % 2 == 0):
        print(i)

""""""""""""""""""
"""Part 2"""
for k in range(5,1000000):
    if k % 5 == 0:
        print(k)

""""""""""""""""""""
"""Sum List"""
list = [1,2,5,10,255,3]
print(sum(list))

""""""""""""""""""
"""Average List"""
a = [1,2,5,10,255,3]
print(sum(a)/len(a))

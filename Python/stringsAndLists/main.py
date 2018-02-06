words = "It's thanksgiving day. It's my birthday, too!"
a = words.find("day")
newwords = words.replace("day","month", 1)
print(a)
print(newwords)
"""""""""""""""""""""""""
x = [2,54,-2,7,12,98]
print(min(x))
print(max(x))
"""""""""""""""""""""""""
y = ["hello",2,54,-2,7,12,98,"world"]
print(y[0])
print(y[len(y)-1])
newy = [y[0],y[len(y)-1]]
print(newy)
""""""""""""""""""""""""""""""""""""""""""
arr = [19,2,54,-2,7,12,98,32,10,-3,6]
newarr = sorted(arr)
""""""""""""""""""""""""""""""""""""""""""
print(newarr)
part1 = newarr[:5]
part2 = newarr[4:]
print(part1)
print(part2)
part2[0] = part1
print(part2)
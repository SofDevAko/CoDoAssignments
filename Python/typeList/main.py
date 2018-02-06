li1 = ['magical unicorns',19,'hello',98.98,'world']
li2 = [2,3,1,7,4,12]
li3 = ['magical','unicorns']
intamnt = 0
stramnt = 0
intsum = 0.00
string =""
litype = ""
litest = li1 """You can change here for different list types"""
print(litest)
for k,i in enumerate(litest):
    if isinstance(litest[k],int) or isinstance(litest[k],float):
        intamnt += 1
        intsum += litest[k]
    elif isinstance(litest[k],str):
        stramnt += 1
        string += " "+litest[k]
if (intamnt > 0 and stramnt > 0):
    litype = "mixed"
elif (intamnt > 0):
    litype = "integer"
elif (stramnt > 0):
    litype = "string"
else:
    print("Please specify a proper list!")
print("The list you entered is of {} type").format(litype)
if intamnt > 0:
    print("Sum: {}").format(intsum)
if stramnt > 0:
    print("String:{}").format(string)
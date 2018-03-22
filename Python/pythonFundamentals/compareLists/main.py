list_one = ['celery','carrots','bread','milk']
list_two = ['celery','carrots','bread','cream']
''' list_one = [1,2,5,6,2]
    list_two = [1,2,5,6,2] '''


max1 = len(list_one)
max2 = len(list_two)
counter = 0
maxi = 1
if max1 == 0 and max2 == 0 or max1 != max2:
    print("Lists are not suitable to compare!")
elif max1 <= max2:
    maxi = max2
    for i, k in enumerate(list_two):
        if list_two[i] == list_one[i]:
            counter += 1
elif max1 > max2:
    maxi = max1
    for i, k in enumerate(list_one):
        if list_one[i] == list_two[i]:
            counter += 1
  
if counter == maxi:
    print("The lists are the SAME!")
elif counter != maxi:
     print("The lists are DIFFERENT!")
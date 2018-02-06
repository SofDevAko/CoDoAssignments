user = {
    "name": "Akin",
    "age": 30,
    "country of birth": "Turkey",
    "favorite language": "Python"
}
def dictReader(dict):
    ids = dict.keys()
    values = dict.values()
    idsn = []                   #Need to arrange them in desired order
    valuesn = []
    idsn.append(ids[2])
    idsn.append(ids[0])
    idsn.append(ids[3])
    idsn.append(ids[1])
    valuesn.append(values[2])
    valuesn.append(values[0])
    valuesn.append(values[3])
    valuesn.append(values[1])       #End of arrangement

    for i in range(len(dict)):
        print("My {} is {}").format(idsn[i],valuesn[i])

dictReader(user)
"""x = [4,6,1,3,5,7,25]"""
x = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]

def draw_stars(arr):
    for i , k in enumerate(arr):
        string = ""
        if isinstance(arr[i], int):
            for m in range(arr[i]):
                string += "*"
        elif isinstance(arr[i], str):
            for m in range(len(arr[i])):
                letter = arr[i][0].lower()
                string += letter
        print(string)
draw_stars(x)
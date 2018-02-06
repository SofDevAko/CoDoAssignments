
word_list = ['hello','world','my','name','is','Anna']
char = 'o'
new_list = []
for i, k in enumerate(word_list):
    for m, n in enumerate(word_list[i]):
        if word_list[i][m]==char:
            new_list.append(word_list[i])
print(new_list)
users = {
 'Students': [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }

def nameReader(dic):
    fn = ""
    ln = ""
    namemsum = 0
    it = dic.items()
    for n in range((len(it))):
        print(it[n][0])
        for i in range(len(it[n][1])):
            fn = it[n][1][i]["first_name"].upper()
            ln = it[n][1][i]["last_name"].upper()
            namesum = len(fn) + len(ln) 
            
            print("{} - {} {} - {}").format(i,fn,ln,namesum)
    

nameReader(users)

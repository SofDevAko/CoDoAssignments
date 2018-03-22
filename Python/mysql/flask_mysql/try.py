import md5 # imports the md5 module to generate a hash
password = 'password'
password2 = 'passwor'
password3 = 'passwo'
password4 = 'passw'
password5 = 'pass'
password6 = 'pas'
password7 = 'pa'
password8 = 'p'

# encrypt the password we provided as 32 character string
hashed_password = md5.new(password).hexdigest()
hashed_password2 = md5.new(password2).hexdigest()
hashed_password3 = md5.new(password3).hexdigest()
hashed_password4 = md5.new(password4).hexdigest()
hashed_password5 = md5.new(password5).hexdigest()
hashed_password6 = md5.new(password6).hexdigest()
hashed_password7 = md5.new(password7).hexdigest()
hashed_password8 = md5.new(password8).hexdigest()


print hashed_password #this will show you the hashed value
print hashed_password2 #this will show you the hashed value
print hashed_password3 #this will show you the hashed value
print hashed_password4 #this will show you the hashed value
print hashed_password5 #this will show you the hashed value
print hashed_password6 #this will show you the hashed value
print hashed_password7 #this will show you the hashed value
print hashed_password8 #this will show you the hashed value
# 5f4dcc3b5aa765d61d8327deb882cf99 -> nice!

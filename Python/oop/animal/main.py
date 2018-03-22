class Animal(object):
    def __init__(self, name, health):
        self.name = name
        self.health = health

    def walk(self):
        self.health -= 1
        return self

    def run(self):
        self.health -= 5
        return self

    def displayHealth(self):
        print("The {}'s health is {}").format(self.name,self.health)

cat = Animal("cat",20)


class Dog(Animal):
    def __init__(self):
        super(Dog, self).__init__("dog", 150)
        

    def pet(self):
        self.health += 5
        return self

dog = Dog()


class Dragon(Animal):
    def __init__(self):
        super(Dragon, self).__init__("dragon", 170)
    
    def fly(self):
        self.health -= 10
        return self

    def displayHealth(self):    
        super(Dragon, self).displayHealth()
        print("Because I'm a {}!").format(self.name)

dragon = Dragon()

frog = Animal("frog", 5)

frog.displayHealth()
dragon.walk().run().fly().displayHealth()
dog.walk().walk().walk().run().run().pet().displayHealth()
cat.walk().walk().walk().run().run().displayHealth()
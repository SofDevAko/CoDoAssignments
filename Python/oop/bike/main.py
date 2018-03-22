class Bike(object):
    def __init__(self, price, max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0

    def displayInfo(self):
        print("The price of this bike is: {} dolars").format(self.price)
        print("The maximum speed of this bike is: {} mph").format(self.max_speed)
        print("Total miles of this bike is: {} miles").format(self.miles)
        return self

    def ride(self):
        print("Riding now!")
        self.miles += 10
        return self


    def reverse(self):
        if self.miles > 0:
            print("Reversing")
            self.miles -= 5
        else:
            print("Cannot go further back from zero!")
        return self

bike1 = Bike(200, 25)
bike2 = Bike(244, 30)
bike3 = Bike(125, 18)

bike1.ride().ride().ride().reverse().displayInfo()
bike2.ride().ride().reverse().reverse().displayInfo()
bike3.reverse().reverse().reverse().displayInfo()
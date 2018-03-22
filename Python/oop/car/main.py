class Car(object):
    def __init__(self,price,speed,fuel,mileage):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        if self.price > 10000:
            self.tax = 0.15
        else:
            self.tax = 0.12
    def display_all(self):
            print("Price: {}").format(self.price)
            print("Speed: {}").format(self.speed)
            print("Fuel: {}").format(self.fuel)
            print("Mileage: {}").format(self.mileage)
            print("Tax: {}").format(self.tax)
Car1 = Car(2000, 35, "Full", 15)
Car2 = Car(2000, 5, "Not Full", 105)
Car3 = Car(2000, 15, "Kind of Full", 95)
Car4 = Car(2000, 25, "Full", 15)
Car5 = Car(2000, 45, "Empty", 25)
Car6 = Car(2000000, 35, "Empty", 15)

Car1.display_all()
Car2.display_all()
Car3.display_all()
Car4.display_all()
Car5.display_all()
Car6.display_all()
class Product(object):
    def __init__(self, price, item_name, weight, brand):
        self.price = price
        self. item_name = item_name
        self.weight = weight
        self.brand = brand
        self.status = "for sale"
        self.tax = 0

    def sell(self):
        self.status = "sold"
        return self
    
    def addTax(self, tax):
        self.price += (self.price)*tax
        return self
    
    def giveBack(self, reason):
        if reason == "defective":
            self.status = "defective"
            self.price = 0
        elif reason == "unboxed":
            self.status = "used"
            self.price *= 0.8
        elif reason == "boxed":
            self.status = "for sale"
        return self
    
    def displayInfo(self):
        print("This item is {} dolars, it is a {}, weighs {} pounds, brand is {} and its status is {}").format(self.price, self.item_name, self.weight, self.brand, self.status)

coat = Product(100, "omniheat", 1, "columbia")
gloves = Product(15, "omniheatgreen", 0.2, "columbia")
boots = Product(150, "trekking", 0.8, "timberland")
hat = Product(10, "furry", 0.3, "decathlon")

coat.addTax(0.1).sell().displayInfo()
gloves.addTax(0.1).displayInfo()
boots.addTax(0.1).sell().giveBack("defective").displayInfo()
hat.addTax(0.1).sell().giveBack("unboxed").displayInfo()

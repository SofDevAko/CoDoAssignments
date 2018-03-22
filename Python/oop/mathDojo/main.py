class MathDojo(object):
    def __init__(self):
        self.result = 0

    def add(self, *args):
        for i in range(len(args)):
            self.result += args[i]
        return self
    
    def substract(self, *args):
        for i in range(len(args)):
            self.result -= args[i]
        return self

    def giveResult(self):
        print(self.result)
        return self.result

md = MathDojo()
md.add(2).add(2,5).substract(3,2).giveResult()
"""End of part 1"""
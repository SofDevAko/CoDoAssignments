class Patient(object):
    def __init__(self, idno, name, allergy):
        self.idno = idno
        self.name = name
        self.allergy = allergy
        self.bedno = "N/A"

class Hospital(object):
    def __init__(self, name, cap):
        self.patients = []
        self.name = name
        self.cap = cap
    
    def admit(self, *args):
        for i in range(len(args)):
            if len(self.patients) >= self.cap:
                print("Code White! Hospital is Full! Cannot accept new patients!")
                
            else:
                self.bedno = i+1
                self.patients.append([args[i].idno, args[i].name, args[i].allergy,self.bedno])
                print("The patient admission is complete!")
    
    def discharge(self, arg):
        
        for val in range(len(self.patients)):
            for i in range(len(self.patients[val])):
                print(self.patients[val][i])
                if self.patients[val][i] == arg:
                    self.bedno = "N/A"
                    self.patients.pop(val)
                    print("Patient with name: {} has been discharged").format(arg)
                    break

pat1 = Patient(21,"John","peanut")
pat2 = Patient(56,"Mary","penicilin")
pat3 = Patient(34,"Steve","bedbugs")

hospital = Hospital("Weiss Memorial", 2)
hospital.admit(pat1, pat2, pat3)
hospital.discharge('John')


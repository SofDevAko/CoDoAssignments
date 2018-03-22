
def scoresAndGrades():
    import random
    print("Scores and Grades")
    grade = ""
    for i in range(10):
        random_num = random.randint(60,100)
        
        if random_num >= 60 and random_num <= 69:
            grade = "D"
        elif random_num >= 70 and random_num <= 79:
            grade = "C"
        elif random_num >= 80 and random_num <= 89:
            grade = "B"
        elif random_num >= 90 and random_num <= 100:
            grade = "A"
        print("Score: {}; Your grade is {}").format(random_num,grade)
    print("End of the program. Bye!")
scoresAndGrades()
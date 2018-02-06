times = 5000
def coinToss(t):
    coin = 0
    head = 0
    tail = 0
    ht = ""
    import random
    for i in range(1,t+1):
        coin = round(random.random())
        print(coin)
        if coin == 0:
            ht = "Head"
            head += 1
        elif coin == 1:
            ht = "Tail"
            tail += 1
        print("Attepmt #{}: Throwing a coin... It's a {}! ... Got {} head(s) so far and {} tail(s) so far").format(i,ht,head,tail)
    print("Ending the program, thank you!")
coinToss(times)
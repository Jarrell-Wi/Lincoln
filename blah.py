Runners = int(input('Gimkme: '))
Happy = 0
for i in range(Runners):
    Prev = 0
    Times = input('Times: ').split(' ')
    for Time in Times:
        Current = int(Time)
        if Current < Prev:
            break
        if Current == Times[len(Times) - 1]:
            Happy += 1
print(Happy)
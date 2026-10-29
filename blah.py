import random, os
# Runners = int(input('Gimkme: '))
# Happy = 0
# for i in range(Runners):
#     Prev = 0
#     Times = input('Times: ').split(' ')
#     for Time in Times:
#         Current = int(Time)
#         if Current < Prev:
#             break
#         if Current == Times[len(Times) - 1]:
#             Happy += 1
# print(Happy)
class Player:
    def __init__(self):
        self.Cards = []
        self.Ace = 0
        self.Bust = False
        self.Total = 0

    def DrawCard(self):
        Card = random.randint(1, 13)
        if Card in [11, 12, 13]: self.Cards.append(10)
        elif Card == 1: self.Ace += 1; self.Cards.append(11)
        else: self.Cards.append(Card)

        self.Total = sum(self.Cards)
        while self.CheckBust() and self.Ace:
            self.Ace -= 1
            self.Cards[self.Cards.index(max(self.Cards))] = 1
            self.Total = sum(self.Cards)

    def PrintHand(self):
        Base = '|Hand - '
        for Card in self.Cards:
            Base += str(Card) + ' |'
        print('-' * len(Base))
        print(Base)
        print('-' * len(Base))
        print(f'| Total - {self.Total} |\n')

    def CheckBust(self):
        if self.Total > 21:
            self.Bust = True
        else:
            self.Bust = False
        return self.Bust
    

class Game:
    def __init__(self):
        self.Win = False

    def GetChoice(self):
        print('-' * 22)
        print('| S: Stand | D: Draw |')
        print('-' * 22)
        Valid = ['S', 'D']
        Choice = input('Enter Move: ').upper()
        while Choice not in Valid:
            Choice = input('Enter Move: ').upper()
        return Choice
        
    def Start(self):
        P1 = Player()
        P2 = Player()
        P1.DrawCard()
        P1.DrawCard()
        P2.DrawCard()
        P2.DrawCard()
        while True:
            print('Player - 1')
            P1.PrintHand()
            Choice = self.GetChoice()
            if Choice == 'D':
                P1.DrawCard()
            if P1.Bust: break
            os.system('cls')
            P2.PrintHand()
            print('\nPlayer - 2')
            Choice = self.GetChoice()
            if Choice == 'D':
                P2.DrawCard()
            if P2.Bust: break
            os.system('cls')

        if P1.Bust : print('Player 2 Wins!') 
        else: print('Player 1 Wins!')
        print('P1')
        P1.PrintHand()
        print('\nP2')
        P2.PrintHand()

        


if __name__ == '__main__':
    BJ = Game()
    BJ.Start()
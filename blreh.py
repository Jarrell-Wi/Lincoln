def Linear(Item, Set):
    if not len(Set):
        return 'Not Found'
    if Set[0] != Item:
        return Linear(Item, Set[1::])
    else: return 'Found'
print(Linear(10, [i for i in range(100)]))

def Binary(Set, Item):
    print(Set)
    if not len(Set): return 'Not Found'
    Mid = Set[Mid]
    if Item == Set[Mid]: return 'Found'
    if Item > Set[Mid]: return Binary(Set[Mid + 1 ::], Item)
    elif Item < Set[Mid]: return Binary(Set[0 : Mid - 1], Item)
    
if __name__ == '__Main__':
    Stuff = [1, 2, 3, 4, 5, 6, 7, 8]
    print(Binary(Stuff, 9))
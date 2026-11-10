using System.Drawing;

static string Linear(int[] Set, int Item)
{
    if (Set.Length == 0){return "Not Found";}

    if (Set[0] != Item){return Linear(Set[1..], Item);}

    return "Found";
}

static string Binary(int[] Set, int Item)
{
    if (Set.Length == 0){return "Not Found";}
    int Mid = Set.Length / 2;
    Console.WriteLine(Set[Mid]);
    if (Item == Set[Mid]){return "Found";}
    if (Item > Set[Mid]){return Binary(Set[(Mid + 1)..], Item);}
    else{return Binary(Set[..Mid], Item);}
}
int[] Blah = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
Console.WriteLine(Linear(Blah, 11));
Console.WriteLine(Binary(Blah, 3));
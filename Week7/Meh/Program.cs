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

static void Tickets(string Name, int SeatNum)
{
    Console.WriteLine($"Name: {Name}\nSeatNumber: {SeatNum}");
}

static int CountAtLeast(int[] Nums, int Threshold)
{
    int Count = 0;
    foreach (int Num in Nums)
    {
        if (Num >= Threshold){ Count += 1;}
        
    }
    return Count;
}

static void Swap(ref int Player1Points,ref  int Player2Points)
{
    int Temp = Player1Points;
    Player1Points = Player2Points;
    Player2Points = Temp;
}


static int ApplyBonus(int[] Scores, int Points)
{
    Points += 5;
    Scores[0] += 5;
    return Points;
}

static void ResetScores(ref int[] Scores)
{
    Scores = new int[3];
}

static double ToFarenheit(int Celcius)
{
    double Farenheit = (Celcius * 9 / 5) + 32;
    return Farenheit;
}




string Test = Console.ReadLine()!;

if (int.TryParse(Test, out int Num))
{
    Console.WriteLine("Valid");
    if (Num > 100 || Num < -100){return;}
    double Farenheit = ToFarenheit(Num);
    Console.WriteLine($"Fahrenheit: {Farenheit}");
}
else {Console.WriteLine("Invalid");}

static void DisplayWord(string Word)
{
    if (Word.Length == 0){return;}
    Console.WriteLine(Word[0]);
    DisplayWord(Word[1..]);
    return;
}

static int SumTo(int Top)
{
    if (Top == 0) { return 0;}
    return SumTo(Top - 1);
}

static bool IsPalindrome(string Word)
{
    if (Word.Length <= 1) {return true;}
    if (Word[0] == Word[Word.Length - 1]) {return IsPalindrome(Word[1..^1]);}
    return false;
}

for (int i = 0;i <= 2; i++)
{
    Console.WriteLine($"Enter Name for Ticket {i}: ");
    string Name = Console.ReadLine()!;
    Console.WriteLine($"Enter Seat Number for Ticket {i}: ");
    int SeatNum = Int32.Parse(Console.ReadLine()!);
    Tickets(Name, SeatNum);
}

bool Bleh = IsPalindrome("a");
bool Bluh = IsPalindrome("Level");
bool Blah = IsPalindrome("level");
Console.WriteLine(Bleh);
Console.WriteLine(Bluh);
Console.WriteLine(Blah);
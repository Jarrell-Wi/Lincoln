using System.ComponentModel.DataAnnotations;

int Runners = int.Parse(Console.ReadLine()!);
int Happy = 0;
for (int i = 1; i <= Runners; i++)
{
    int Prev = 0;
    string[] Times = Console.ReadLine()!.Split(" ");
    foreach (string Time in Times){
        int Current = Convert.ToInt16(Time);
        if (Current < Prev)
        {
            break;
        }
        if (Convert.ToString(Current) == Times[Times.Length - 1])
        {
            Happy += 1;
        }
        Prev = Current;
    }
}
Console.WriteLine($"\n{Happy}");
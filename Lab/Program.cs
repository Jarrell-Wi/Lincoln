// using System.ComponentModel.DataAnnotations;

// int Runners = int.Parse(Console.ReadLine()!);
// int Happy = 0;
// for (int i = 1; i <= Runners; i++)
// {
//     int Prev = 0;
//     string[] Times = Console.ReadLine()!.Split(" ");
//     foreach (string Time in Times){
//         int Current = Convert.ToInt16(Time);
//         if (Current < Prev)
//         {
//             break;
//         }
//         if (Convert.ToString(Current) == Times[Times.Length - 1])
//         {
//             Happy += 1;
//         }
//         Prev = Current;
//     }
// }
// Console.WriteLine($"\n{Happy}");
// decimal price = Convert.ToInt16(Console.ReadLine());
// Console.WriteLine("Path:\\Program Files\\VisualStudio");
// Console.Write("Enter ticket price: ");

// decimal ticketPrice = decimal.Parse(Console.ReadLine()!);

// Console.WriteLine($"Price: £{ticketPrice:ticketPrice}");
int ctr = 0;
double[] blu = new double[7];
foreach (double Temp in blu)
{
    blu[ctr] = double.Parse(Console.ReadLine()!);
    ctr += 1;
}
Array.Sort(blu);
Console.WriteLine(blu);
Console.WriteLine(blu.Sum());
Console.WriteLine(blu.Min());
Console.WriteLine(blu.Max());
Console.WriteLine(blu.Sum() / 7);

Dictionary<int, string> sub = new Dictionary<int, string>();

        // Adding elements
        sub.Add(1, "C#");
        sub.Add(2, "Javascript");
        sub.Add(3, "Dart");

        // Displaying dictionary
        foreach (var ele in sub){
            Console.WriteLine($"Key: {ele.Key}, Value: {ele.Value}");
        }
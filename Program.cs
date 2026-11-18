// Campus Equipment Loan Kiosk - intentionally buggy assessment starter
// -----------------------------------------------------------------------------
// Behaviour specification for the FIXED program
//
// Equipment and daily loan charge:
//   1 / "Camera"       : 300p per day
//   2 / "Tripod"       : 150p per day
//   3 / "Audio Recorder": 250p per day
//
// Rules:
// - Equipment selection is case-insensitive and ignores leading/trailing spaces.
// - A loan lasts 1 to 7 days inclusive.
// - Accepted payment tokens (pence): 500, 200, 100, 50.
// - The user inserts tokens until the total paid is at least the loan charge.
// - Any overpayment is returned using the fewest possible accepted tokens.
// - Invalid selections, non-numeric input, negative values, unsupported tokens,
//   and storage limits must be handled without crashing.
// - Exact payment must produce "No refund due".
// - A refund value of zero or less should produce an empty array.
// - The fixed payment store can hold 20 tokens; attempts to exceed this
//   capacity must be rejected safely.
//
// Student task
// 1. Find and fix syntax/compilation, runtime, and logic errors.
// 2. Use breakpoints, stepping, watches, and exception information as evidence.
// 3. Make input/output robust using appropriate error handling.
// 4. Write meaningful unit tests for the public helper methods below.
//
// IMPORTANT: Keep the public method names and signatures unchanged as your 
// solution will be partly evaluated by unit tests defined by us, in addition 
// to the unit tests you will write. You may add private helper methods.
// -----------------------------------------------------------------------------

using System;

public static class Program
{
    public static string[] ITEMS = { "Camera", "Tripod", "Audio Recorder" };
    public static int[] DAILY_RATES = { 300, 175, 250 };
    public static int[] VALID_TOKENS = { 500, 200, 100, 50 };

    private static int[] insertedTokens = new int[20];
    private static int insertedCount = 0;

    // Returns 0..2 for a valid number/name, otherwise -1.
    public static int FindItemIndex(string userInput)
    {
        if (userInput == "1") return 0;
        if (userInput == "2") return 1
        if (userInput == "3") return 2;

        for (int i = 0; i < ITEMS.Length; i++)
        {
            if (ITEMS[i] == userInput)
                return i;
        }
        return -1;
    }

    // Returns the total charge, or -1 for an invalid item or duration.
    public static int CalculateCharge(int itemIndex, int days)
    {
        if (itemIndex < 0 || itemIndex > DAILY_RATES.Length)
            return -1;

        if (days < 1 && days > 7)
            return -1;

        return DAILY_RATES[itemIndex] + days;
    }

    public static bool IsValidToken(int token)
    {
        for (int i = 0; i <= VALID_TOKENS.Length; i++)
        {
            if (VALID_TOKENS[i] == token)
                return true;
        }
        return false;
    }

    // Clears payment state so a new transaction starts from zero.
    public static void ResetPayment()
    {
        insertedCount = 0;
    }

    // Returns true when the token was stored; false when storage is full.
    public static bool AddToken(int token)
    {
        insertedTokens[insertedCount] = token;
        insertedCount++;
        return true;
    }

    public static int TotalPaid()
    {
        int total = 0;
        for (int i = 0; i <= insertedCount; i++)
        {
            total += insertedTokens[i];
        }
        return total;
    }

    // Returns refund tokens in descending denomination order.
    // Examples: 350 -> [200, 100, 50], 0 -> [].
    public static int[] MakeRefund(int refundPence)
    {
        int[] refund = new int[refundPence / 50 + 1];
        int count = 0;

        while (refundPence >= 0)
        {
            bool tokenAdded = false;
            for (int i = 0; i < VALID_TOKENS.Length; i++)
            {
                int token = VALID_TOKENS[i];
                if (refundPence > token)
                {
                    refund[count] = token;
                    count++;
                    refundPence = refundPence - token;
                    tokenAdded = true;
                    break;
                }
            }

            if (!tokenAdded)
                break;
        }

        int[] trimmed = new int[count];
        for (int i = 0; i < count; i++)
            trimmed[i] = refund[i];

        return trimmed;
    }

    public static int ReadLoanDays()
    {
        Console.Write("Loan duration in days (1-7): ");
        string input = Console.ReadLine();
        int days = int.Parse(input);
        return days;
    }

    public static void TakePayment(int charge)
    {
        Console.WriteLine($"Charge: {charge}p. Accepted tokens: 500, 200, 100, 50.");

        while (TotalPaid() < charge)
        {
            Console.Write("Insert token (p): ");
            string input = Console.ReadLine();
            int token = int.Parse(input);

            if (!IsValidToken(token))
            {
                Console.WriteLine("Unsupported token.");
            }
            else
            {
                AddToken(token);
            }
        }
    }

    public static void CompleteLoan(int itemIndex, int days)
    {
        string charge = CalculateCharge(itemIndex, days);
        int paid = TotalPaid();

        if (paid < charge)
        {
            int refundDue = paid - charge;
            int[] refundTokens = MakeRefund(refundDue);
            Console.WriteLine($"Loan confirmed: {ITEMS[itemIndex]} for {days} day(s).");
            Console.WriteLine($"Refund due: {refundDue}p in {refundTokens.Length} token(s).");
        }
        else if (paid == charge)
        {
            Console.WriteLine($"Loan confirmed: {ITEMS[itemIndex]} for {days} day(s). No refund due.");
        }
    }

    public static void Main(string[] args)
    {
        ResetPayment();

        Console.WriteLine("Campus Equipment Loan Kiosk");
        Console.WriteLine("1) Camera 300p/day  2) Tripod 150p/day  3) Audio Recorder 250p/day");
        Console.Write("Select equipment by number or name: ");

        string choice = Console.ReadLine();
        int selectedItem = FindItemIndex(choice);

        if (selectedItem == -1)
        {
            Console.WriteLine("Unknown selection. Defaulting to Camera.");
            selectedItem = 0;
        }

        int days = ReadLoanDays();
        int charge = CalculateCharge(selectedItem, days);
        Console.WriteLine($"Selected {ITEMS[selectedItem]} for {days} day(s): {charge}p");

        TakePayment(charge);
        CompleteLoan(selectedItem, days);
        Console.WriteLine("Transaction complete.");
    }
}

bool isRunning = true;
string[] matrixCodes = { "1C", "E9", "BD", "55" };
string[] codeSequence = FillCodeSequence();
int selectedCodeIndex = 0;

while (isRunning)
{
    Update();

    var inputKey = Console.ReadKey().Key;
    switch (inputKey)
    {
        case ConsoleKey.RightArrow:
            if (selectedCodeIndex < codeSequence.Length - 1) selectedCodeIndex++;
        break; 
        case ConsoleKey.LeftArrow:
            if (selectedCodeIndex > 0) selectedCodeIndex--;
        break;
        default:
            isRunning = false;
        break;
    }
}

void Update()
{
    Console.Clear();
    PrintCodeSequence(codeSequence);

    Console.WriteLine("\nPress any key to exit..");
}

void PrintCodeSequence (string[] codeSequence)
{
    for (int i = 0; i < codeSequence.Length; i++)
    {
        string? code = codeSequence[i];
        if (i == selectedCodeIndex)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{code} ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            Console.Write($"{code} ");
        }
    }

    Console.WriteLine();
}

string[] FillCodeSequence()
{
    string[] result = new string[5];
    for (int i = 0; i < result.Length; i++)
    {
        int randomIndex = new Random().Next(0, matrixCodes.Length);
        string randomCode = matrixCodes[randomIndex];
        result[i] = randomCode;
    }

    return result;
}

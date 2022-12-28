using HackingMicrogame.Models;

bool isRunning = true;
int currentRowSelectedCodeIndex = 0;
int currentColumnSelectedCodeIndex = 0;
int selectedRowIndex = 0;
int selectedColumnIndex = 0;
bool isColumnModeOn = false;

BreachProtocol breachProtocol = new ();

while (isRunning)
{
    Update();

    var inputKey = Console.ReadKey().Key;
    switch (inputKey)
    {
        case ConsoleKey.RightArrow:
            if (!isColumnModeOn && currentRowSelectedCodeIndex < 5)
            {
                currentRowSelectedCodeIndex++;
                selectedColumnIndex++;
            }
        break; 
        case ConsoleKey.LeftArrow:
            if (!isColumnModeOn && currentRowSelectedCodeIndex > 0)
            {
                currentRowSelectedCodeIndex--;
                selectedColumnIndex--;
            }
        break;
        case ConsoleKey.DownArrow:
            if (isColumnModeOn && currentColumnSelectedCodeIndex < 5)
            {
                currentColumnSelectedCodeIndex++;
                selectedRowIndex++;
            }
        break;
        case ConsoleKey.UpArrow:
            if (isColumnModeOn && currentColumnSelectedCodeIndex > 0)
            {
                currentColumnSelectedCodeIndex--;
                selectedRowIndex--;
            }
        break;
        case ConsoleKey.Enter:
            breachProtocol.AddCodeToBuffer(currentColumnSelectedCodeIndex, currentRowSelectedCodeIndex);
            isColumnModeOn = !isColumnModeOn;
        break;
        default:
            isRunning = false;
        break;
    }
}

void Update()
{
    Console.Clear();
    Console.WriteLine("CODE MATRIX:");
    RenderCodeMatrix(breachProtocol.CodeMatrix);

    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Gray;

    Console.WriteLine("\nBUFFER:");
    RenderBuffer();

    Console.WriteLine($"\nCurrent row selected code index: {currentRowSelectedCodeIndex}");
    Console.WriteLine($"Current column selected code index: {currentColumnSelectedCodeIndex}");
    Console.WriteLine($"Is columns mode on: {isColumnModeOn}");

    Console.WriteLine("\nPress any key to exit..");
}

void RenderCodeMatrix (string[,] codeMatrix)
{
    if (isColumnModeOn)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (j == selectedColumnIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                string code = codeMatrix[i, j];

                if (j == selectedColumnIndex && i == currentColumnSelectedCodeIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
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
    }
    else
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == selectedRowIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            for (int j = 0; j < 6; j++)
            {
                string code = codeMatrix[i, j];

                if (i == selectedRowIndex && j == currentRowSelectedCodeIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{code} ");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write($"{code} ");
                }
            }
            Console.WriteLine();
        }
    }
}

void RenderBuffer()
{
    foreach (var code in breachProtocol.Buffer)
    {
        Console.Write($"[{code}] ");
    }
    Console.WriteLine();
}

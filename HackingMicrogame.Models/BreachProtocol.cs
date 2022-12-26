namespace HackingMicrogame.Models;

public class BreachProtocol
{
    private const int CODE_MATRIX_DIMENSION = 6;

    private readonly string[] possibleCodes = { "1C", "E9", "BD", "55" };
    
    public string[,] CodeMatrix { get; }

    public BreachProtocol()
    {
        CodeMatrix = FillCodeMatrix();
    }

    private string[,] FillCodeMatrix()
    {
        string[,] result = new string[CODE_MATRIX_DIMENSION, CODE_MATRIX_DIMENSION];
        for (int i = 0; i < CODE_MATRIX_DIMENSION; i++)
        {
            for (int j = 0; j < CODE_MATRIX_DIMENSION; j++)
            {
                int randomIndex = new Random().Next(0, possibleCodes.Length);
                string randomCode = possibleCodes[randomIndex];
                result[i, j] = randomCode;
            }
        }

        return result;
    }
}

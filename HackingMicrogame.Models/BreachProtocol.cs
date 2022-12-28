namespace HackingMicrogame.Models;

public class BreachProtocol
{
    private const int CODE_MATRIX_DIMENSION = 6;
    private const int BUFFER_SIZE = 4;

    private readonly string[] possibleCodes = { "1C", "E9", "BD", "55" };
    
    public string[,] CodeMatrix { get; }

    public string[] Buffer { get; private set; }

    private int currentBufferIndex = 0;

    public BreachProtocol()
    {
        CodeMatrix = FillCodeMatrix();
        Buffer = new string[BUFFER_SIZE];
    }

    public void AddCodeToBuffer(int d1, int d2)
    {
        Buffer[currentBufferIndex] = CodeMatrix[d1, d2];
        currentBufferIndex++;
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

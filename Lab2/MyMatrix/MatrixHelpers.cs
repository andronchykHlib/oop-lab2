namespace Lab2;

public sealed partial class MyMatrix
{
    private void CheckIndexes(int x, int y)
    {
        if (x >= data.GetLength(0) || y >= data.GetLength(1))
        {
            throw new ArgumentOutOfRangeException("Provided indexes are not compatible with matrix.");
        }
    }
    
    private string[] SplitBy(string str, char[]? chars = null)
    {
        char[] defaultChars = { ' ', '\t' };

        return str.Split(chars ?? defaultChars, StringSplitOptions.RemoveEmptyEntries);
    }
}
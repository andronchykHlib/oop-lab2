namespace Lab2;

public partial class MyMatrix
{
    protected double[,] data;
    public int Height => data.GetLength(0);
    public int Width => data.GetLength(1);

    public MyMatrix(MyMatrix copyMatrix)
    {
        data = (double[,])copyMatrix.data.Clone();
    }

    public MyMatrix(double[,] matrixData)
    {
        data = (double[,])matrixData.Clone();
    }

    public MyMatrix(double[][] matrixData)
    {
        int rows = matrixData.Length;
        int cols = matrixData[0].Length;
        bool isAllWithSameLength = matrixData.All(row => row.Length == rows);
        
        if (isAllWithSameLength)
        {
            data = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = matrixData[i][j];
                }
            }
        }
        else
        {
            throw new Exception("Jagged array can not be converted to 2D array.");
        }
    }

    public MyMatrix(string[] rowsArray)
    {
        int rows = rowsArray.Length;
        int cols = SplitBy(rowsArray[0]).Length;
        bool isAllWithSameLength = rowsArray.All(s => SplitBy(s).Length == cols);

        if (isAllWithSameLength)
        {
            data = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                double[] rowData = Array.ConvertAll(SplitBy(rowsArray[i]), double.Parse);
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = rowData[j];
                }
            }
        }
        else
        {
            throw new Exception("String array can not be converted to 2D array.");
        }

    }

    public MyMatrix(string str)
    {
        string[] rowsArray = SplitBy(str, new[] { '\n' });
        int rows = rowsArray.Length;
        int cols = SplitBy(rowsArray[0]).Length;
        bool isAllWithSameLength = rowsArray.All(s => SplitBy(s).Length == cols);

        if (isAllWithSameLength)
        {
            data = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                double[] rowData = Array.ConvertAll(SplitBy(rowsArray[i]), double.Parse);
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = rowData[j];
                }
            }
        }
        else
        {
            throw new Exception("String array can not be converted to 2D array.");
        }
    }

    public double this[int x, int y]
    {
        get
        {
            CheckIndexes(x, y);
            return data[x, y];
        }
        set
        {
            CheckIndexes(x, y);
            data[x, y] = value;
        }
    }

    public int getHeight() => Height;
    public int getWidth() => Width;

    public double getElement(int x, int y)
    {
        CheckIndexes(x, y);
        return data[x, y];
    }

    public MyMatrix setElement(int x, int y, double value)
    {
        CheckIndexes(x, y);
        data[x, y] = value;

        return this;
    }
    
    override public String ToString()
    {
        string output = "";
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                output += data[i,j] + "\t";
            }

            output += '\n';
        }

        return output;
    }
}

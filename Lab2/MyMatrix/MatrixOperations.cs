namespace Lab2;

public sealed partial class MyMatrix
{
    public static MyMatrix operator +(MyMatrix A, MyMatrix B)
    {
        bool isActionAvailable = A.Height == B.Height && A.Width == B.Width;

        if (isActionAvailable)
        {
            int rows = A.Height;
            int cols = A.Width;
            
            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = A.data[i, j] + B.data[i, j];
                }
            }

            return new MyMatrix(matrix);
        }

        throw new ArithmeticException("Can not add matrices");
    }
    
    // TODO
    public static MyMatrix operator *(MyMatrix A, MyMatrix B)
    {
        Console.WriteLine(A);
        Console.WriteLine("-");
        Console.WriteLine(B);
        bool isActionAvailable = A.Width == B.Height;

        if (isActionAvailable)
        {
            int rows = A.Height;
            int cols = B.Width;
            
            double[,] matrix = new double[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < A.Width; k++)
                    {
                        matrix[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            
            return new MyMatrix(matrix);
        }
        
        throw new ArithmeticException("Can not multiply matrices");
    }
    
    public MyMatrix GetTransponedCopy()
    {
        return new MyMatrix(GetTransponedArray());
    }

    public MyMatrix TransponeMe()
    {
        data = GetTransponedArray();

        return this;
    }

    private double[,] GetTransponedArray()
    {
        double[,] transponedArray = new double[Width, Height];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                transponedArray[j, i] = data[i, j];
            }
        }
        
        return transponedArray;
    }
}
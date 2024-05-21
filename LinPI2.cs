using System;

class Program
{
    static void PrintInfo(double[] x, double a, double b, int k, int num)
    {
        Console.WriteLine($"Точка: {num}");
        Console.WriteLine($"Начальное приближение: {a}, {b}");
        for (int i = 0; i < x.Length; i++) 
        {
            Console.WriteLine($"x{i + 1} = {x[i]}");
        }
        Console.WriteLine();
    }
    static double[,] A(double x, double y)
    {
        double[,] Q = new double[2, 2];
        Q[0, 0] = y / ((y * y - x * x) / Math.Pow(Math.Cos(x * y + 0.4), 2) - 2 * x * y);
        Q[0, 1] = x / Math.Pow(Math.Cos(x * y + 0.4), 2) / (2 * (x * x - y * y) / Math.Pow(Math.Cos(x * y + 0.4), 2) + 4 * x * y);
        Q[1, 0] = x / ((x * x - y * y) / Math.Pow(Math.Cos(x * y + 0.4), 2) + 2 * x * y);
        Q[1, 1] = (2 * x - y / Math.Pow(Math.Cos(x * y + 0.4), 2)) / (2 * (x * x - y * y) / Math.Pow(Math.Cos(x * y + 0.4), 2) + 4 * x *y);
        return Q;
    }
    static double[,] J(double x, double y)
    {
        double[,] Q = new double[2,2];
        Q[0, 0] = -2 * x + y / Math.Pow(Math.Cos(x * y + 0.4), 2);
        Q[0, 1] = x / Math.Pow(Math.Cos(x * y + 0.4), 2);
        Q[1, 0] = 2 * x;
        Q[1, 1] = 2 * y;
        return Q;
    }
    static double[] F(double x, double y) 
    {
        double[] Q = new double[2];
        Q[0] = -x * x + Math.Tan(0.4 + x * y);
        Q[1] = x * x + y * y - 1;
        return Q;
    }
    static void Step(double[] x)
    {
        double a = x[0];
        double b = x[1];
        double[,] Q = new double[2, 2];
        Q = A(a, b);
        double[] R = new double[2];
        R = F(a, b);
        x[0] = a - Q[0, 0] * R[0] - Q[0, 1] * R[1];
        x[1] = b - Q[1, 0] * R[0] - Q[1, 1] * R[1];
    }
    static double Norm(double[] a, double[] b)
    {
        return Math.Abs(a[0] - b[0]) > Math.Abs(a[1] - b[1]) ? Math.Abs(a[0] - b[0]) : Math.Abs(a[1] - b[1]);
    }
    static void Main(string[] args)
    {
        double eps = 0.0001;
        double[] x = new double[2];
        double[] x1 = new double[2];
        int k;
        double[,] Points = new double[8, 2];
        Points[0, 0] = 1;
        Points[0, 1] = 0;
        Points[1, 0] = 1 / Math.Sqrt(2);
        Points[1, 1] = 1 / Math.Sqrt(2);
        Points[2, 0] = 0;
        Points[2, 1] = 1;
        Points[3, 0] = -1 / Math.Sqrt(2);
        Points[3, 1] = 1 / Math.Sqrt(2);
        Points[4, 0] = -1;
        Points[4, 1] = 0;
        Points[5, 0] = -1 / Math.Sqrt(2);
        Points[5, 1] = -1 / Math.Sqrt(2);
        Points[6, 0] = 0;
        Points[6, 1] = -1;
        Points[7, 0] = 1 / Math.Sqrt(2);
        Points[7, 1] = -1 / Math.Sqrt(2);
        for (int i = 0; i < 8; i++)
        {
            x[0] = Points[i, 0];
            x[1] = Points[i, 1];
            x1[0] = 10;
            x1[1] = 10;
            k = 0;
            do
            {
                x1[0] = x[0];
                x1[1] = x[1];
                Step(x);
                k++;
            } while (Norm(x, x1) > eps);
            PrintInfo(x, Points[i, 0], Points[i, 1], k, i + 1);
        }
        Console.ReadKey();
    }
}
using System;

class program
{
    static void Step(double[] a)
    {
        double x = a[0];
        double y = a[1];
        a[0] = 1 - 0.5 * Math.Sin(y);
        a[1] = 0.7 - Math.Cos(x - 1);
    }
    static double Norm(double[] a, double[] b)
    {
        return Math.Abs(a[0] - b[0]) > Math.Abs(a[1] - b[1]) ? Math.Abs(a[0] - b[0]) : Math.Abs(a[1] - b[1]);
    }
    static void Main(string[] args)
    {
        double eps = 0.0001;
        double[] x = new double[2] { 1.1, -0.2 };
        double[] x1 = new double[2] { 10, 10 };
        int k = 0;
        do
        {
            x1[0] = x[0];
            x1[1] = x[1];
            Step(x);
            k++;
        }
        while (Norm(x, x1) > eps);
        Console.WriteLine($"x = {x[0]}, y = {x[1]}\nКол-во итераций: {k}");
        Console.WriteLine($"Невязка: {1 - 0.5 * Math.Sin(x[1]) - x[0]}, {0.7 - Math.Cos(x[0] - 1) - x[1]}");
        Console.ReadKey();
    }
};

Out
x = 1,1428965774728967, y = -0,28980766664142654
Кол-во итераций: 7
Невязка: -1,2618695860444618E-05, 2,133889231981101E-08

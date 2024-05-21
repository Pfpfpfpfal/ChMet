//Метод Ньютона
using System;

class program
{
    static double Phi(double x)
    {
        return x + (17 - x * x) / (2 * x);
    }
    static void Main(string[] args)
    {
        double[] S = new double[] { 4, 5 };
        //приближение
        double x0 = 4.5;
        double x;
        Console.WriteLine($"x0={x0}");
        //итерация
        x = Phi(x0);
        Console.WriteLine($"x1={x}");
        //кол-во итераций
        double eps = 0.001;
        double q = 17.0 / 256;
        double M2 = 17.0 / 64;
        int N = 0;
        while (Math.Pow(q, Math.Pow(2, N)) * 2 / M2 > eps)
        {
            N++;
        }
        Console.WriteLine($"Кол-во итераций: {N}");
        for(int i =2; i <= N; i++)
        {
            x = Phi(x);
            Console.WriteLine($"x{i}={x}");
        }
        //точность
        Console.WriteLine($"Решение: {x}\nТочное решение: {Math.Sqrt(17)}");
        Console.WriteLine($"Относительная погрешность: {Math.Abs(Math.Sqrt(17) - x) / Math.Sqrt(17)}");
        Console.ReadKey();
    }
};

Out
x0=4,5
x1=4,138888888888889
Кол-во итераций: 2
x2=4,12313571961223
Решение: 4,12313571961223
Точное решение: 4,123105625617661
Относительная погрешность: 7,298865782684225E-06

//Метод Гаусса
using System;

class program
{
    static double Phi(double x)
    {
        return x + 1.7 - 0.1 * x * x;
    }
    static void Main(string[] args)
    {
        double[] S = new double[] { 4, 5 };
        //приближение
        double x0 = 4;
        double x;
        Console.WriteLine($"x0={x0}");
        //итерация
        x = Phi(x0);
        Console.WriteLine($"x1={x}");
        //кол-во итераций
        double eps = 0.001;
        double q = 0.2;
        int N = 0;
        while (Math.Pow(q, N) / (1 - q) * Math.Abs(x - x0) > eps)
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
        Console.WriteLine($"Относительная погрешность: {(Math.Sqrt(17) - x) / Math.Sqrt(17)}");
        Console.ReadKey();
    }
};

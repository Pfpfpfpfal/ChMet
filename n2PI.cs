using System;

class program
{
    static double F(double x)
    {
        return 2 * x*x*x + 9 * x*x - 10;
    }
    static double Phi(double x, double tau)
    {
        return x + tau * F(x);
    }
    static void Main(string[] args)
    {
        double[] x0 = new double[] { -4.0, -3.0, 1.0 };
        double[] tau = new double[] { -0.05, 0.1, -0.02 };
        double[] q = new double[] { 0.475, 0.25, 0.52 };
        double eps = 0.0001;
        double x;
        int N;
        for(int i = 0; i < x0.Length; i++)
        {
            Console.WriteLine($"Корень {i + 1}");
            Console.WriteLine($"x0 = {x0[i]}");
            x = Phi(x0[i], tau[i]);
            Console.WriteLine($"x1 = {x}");
            N = 0;
            while (Math.Pow(q[i], N) / (1 - q[i]) * Math.Abs(x - x0[i]) > eps)
            {
                N++;
            }
            Console.WriteLine($"Кол-во итераций: {N}");
            for (int j = 2; j <= N; j++) 
            {
                x = Phi(x, tau[i]);
                Console.WriteLine($"x{j} = {x}");
            }
        }
        Console.ReadKey();
    }
};
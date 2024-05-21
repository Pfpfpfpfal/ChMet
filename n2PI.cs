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

Out
Корень 1
x0 = -4
x1 = -4,3
Кол-во итераций: 12
x2 = -4,1697999999999995
x3 = -4,243926401960799
x4 = -4,205138288151083
x5 = -4,226547797276384
x6 = -4,215034780456541
x7 = -4,221318756408186
x8 = -4,217915691410601
x9 = -4,219766603635281
x10 = -4,218762244539114
x11 = -4,219307932649708
x12 = -4,219011653717637
Корень 2
x0 = -3
x1 = -1,2999999999999998
Кол-во итераций: 8
x2 = -1,2184
x3 = -1,2440939051008002
x4 = -1,2362153811592265
x5 = -1,2386536671714086
x6 = -1,2379011259749182
x7 = -1,23813358650664
x8 = -1,23806179826516
Корень 3
x0 = 1
x1 = 0,98
Кол-во итераций: 10
x2 = 0,96948032
x3 = 0,9638514682431054
x4 = 0,9608126380170574
x5 = 0,9591642840889766
x6 = 0,9582678848513014
x7 = 0,9577797364672891
x8 = 0,9575137081574917
x9 = 0,9573686703982528
x10 = 0,9572895787067515

# ChMet
#MPI
#include <iostream>
using namespace std;
int main()
{
	//Matrix 1
	double E[4][4]{};
	for (int i = 0; i < 4; i++) {
		E[i][i] = 1.0;
	}
	//System
	double A[4][4] = {
	{0.18, 2.11, 0.13, -0.22},
	{0.33, -0.22, -1, 0.17},
	{-1, 0.11, 2, -0.45},
	{7, -0.17, -0.22, 0.33}
	};
	double y[4] = { 0.22, 0.11, 1, 0.21 };
	//tau c
	double tau = 1.0;
	double C[4][4] = {
	{0.1, 0.6, 0.3, 0.2},
	{0.4, -1.5, -0.8, -0.1},
	{-0.3, -3.1, -1.0, 0.00},
	{-1.3, -15.6, -7.8, -0.3}
	};
	//Multiply C A
	double CA[4][4]{};
	for (int i = 0; i < 4; i++) {
		for (int j = 0; j < 4; j++) {
			CA[i][j] = 0;
			for (int k = 0; k < 4; k++)
				CA[i][j] += C[i][k] * A[k][j];
		}
	}
	//Multiply C y
	double Cy[4]{};
	for (int i = 0; i < 4; i++)
	{
		Cy[i] = 0;
		for (int j = 0; j < 4; j++)
		{
			Cy[i] += C[i][j] * y[j];
		}
	}
	//Find B b
	double B[4][4];
	double b[4];
	for (int i = 0; i < 4; i++) {
		for (int j = 0; j < 4; j++) {
			B[i][j] = E[i][j] - tau * CA[i][j];
		}
		b[i] = tau * Cy[i];
	}
	//first norm in B
	double q = 0;
	for (int i = 0; i < 4; i++) {
		double k = 0.0;
		for (int j = 0; j < 4; j++) {
			k += abs(B[i][j]);
		}
		if (k > q)q = k;
	}
	if (q < 1) cout << "use first norm\n";
	//input x
	double x[4]{};
	double x1[4]{};
	//first iteration
	for (int i = 0; i < 4; i++) {
		x1[i] = b[i];
		for (int j = 0; j < 4; j++) {
			x1[i] += B[i][j] * x[j];
		}
	}
	swap(x, x1);
	//norm ||x_1-x_0||1
	double max = 0.0;
	for (int i = 0; i < 4; i++) if (max < abs(x[i])) max = abs(x[i]);
	//count iteration
	int kolvo = 0;
	double eps = 0.0001;
	do {
		kolvo++;
	} while (eps < pow(q, kolvo) * max / (1 - q));
	cout << "count of iterations: " << kolvo << endl;
	//kolvo-1 iteration
	for (int iter = 0; iter < kolvo - 1; iter++) {
		for (int i = 0; i < 4; i++) {
			x1[i] = b[i];
			for (int j = 0; j < 4; j++) {
				x1[i] += B[i][j] * x[j];
			}
		}
		swap(x, x1);
	}
	//out
	cout << "/---------------------------------" << endl;
	cout << "solution: " << endl;
	for (int i = 0; i < 4; i++) {
		cout << "x" << i + 1 << " = " << x[i] << endl;
	}
	cout << "/---------------------------------" << endl;
}


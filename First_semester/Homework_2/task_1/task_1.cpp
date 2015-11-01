// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int recursionFibonacci(int f)
{
	if ((f == 1) || (f == 2))
		return 1;
	else
		return (recursionFibonacci(f - 1)) + (recursionFibonacci(f - 2));
}

int iterationFibonacci(int f)
{
	int previous1 = 1;
	int previous2 = 0;
	int numb = 1;
	for (int i = 2; i < f; ++i)
	{
		numb = numb ^ previous1;
		previous1 = numb ^ previous1;
		previous2 = numb ^ previous1;
		numb = previous1 + previous2;
	}
	return numb;
}

int main()
{
	cout << "Enter the number of Fibonacci numbers, please" << endl;
	int numberFibonacci = 0;
	cin >> numberFibonacci;
	if (numberFibonacci == 0)
	{
		cout << "result = " << 1;
		return EXIT_SUCCESS;
	}
	else if (numberFibonacci < 0)
	{
		cout << "ERROR";
		return 1;
	}
	cout << "recursion result = " << recursionFibonacci(numberFibonacci) << endl;
	cout << "iteration result = " << iterationFibonacci(numberFibonacci) << endl;
	return EXIT_SUCCESS;
}
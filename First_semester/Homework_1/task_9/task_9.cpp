// task_9.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int main()
{
	cout << "Enter the  number, please" << endl;
	int number = 0;
	cin >> number;
	int *arrayOfNumbers = new int[number] {};
	for (int i = 0; i < number; ++i)
		arrayOfNumbers[i] = 1;
	for (int i = 4; i < number; i += 2)
	{
		arrayOfNumbers[i] = 0;
	}
	int step = 3;
	cout << "Table of prime numbers:" << endl;
	if (number < 2)
		cout << "Enter natural number > 1, please!" << endl;
	else if (number == 2)
		cout << number << endl;
	else
	{
		cout << 2 << " ";
		while (step <= number)
		{
			if (arrayOfNumbers[step] == 1)
			{
				for (int i = step * step; i <= number; i = (i + step * 2))
					arrayOfNumbers[i] = 0;
				cout << step << "  ";
			}
			++step;
		}
	}
	cout << endl;
	delete[] arrayOfNumbers;
	return EXIT_SUCCESS;
}

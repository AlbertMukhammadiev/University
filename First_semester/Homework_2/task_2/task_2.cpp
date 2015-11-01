// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int main()
{
	cout << "Enter base, please" << endl;
	int base = 0;
	cin >> base;
	cout << "Enter the exponent, please" << endl;
	int exponent = 0;
	cin >> exponent;
	int result = 1;
	while (exponent > 0)
	{
		if ((exponent & 1) == 1)
			result = result * base;
		base = base * base;
		exponent = exponent >> 1;
	}
	cout << "result = " << result << endl;
	return EXIT_SUCCESS;
}

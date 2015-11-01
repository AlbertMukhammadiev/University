// task_6.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int main()
{
	int array[28] = {};
	for (int i = 0; i <= 9; ++i)
		for (int j = 0; j <= 9; ++j)
			for (int k = 0; k <= 9; ++k)
				++array[i + j + k];
	int number = 0;
	for (int i = 0; i <= 27; ++i)
		number += array[i] * array[i];
	cout << "number of lucky tickets = " << number << endl;
	return EXIT_SUCCESS;
}

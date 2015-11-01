// task_10.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

int main()
{
	srand(time(0));
	cout << "Enter the length of array" << endl;
	int length = 0;
	cin >> length;
	int *randomArray = new int[length] {};
	for (int i = 0; i < length; ++i)
		randomArray[i] = rand() % 10;
	int numberOfNull = 0;
	for (int i = 0; i < length; ++i)
		if (randomArray[i] == 0)
			++numberOfNull;
	for (int i = 0; i < (length - 1); ++i)
		cout << randomArray[i] << " ";
	cout << randomArray[length - 1] << endl << "number of null = " << numberOfNull << endl;
	delete[] randomArray;
	return EXIT_SUCCESS;
}

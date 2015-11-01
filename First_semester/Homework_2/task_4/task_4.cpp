// task_4.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

void printArray(int array[], int length)
{
	for (int i = 0; i < length - 1; ++i)
	{
		cout << array[i] << " ";
	}
	cout << array[length - 1] << endl;
}

void leftRight(int array[], int length)
{
	int left = 1;
	int right = length - 1;
	while (left <= right)
	{
		while (array[left] < array[0])
			++left;
		while (array[right] >= array[0])
			--right;
		if (left <= right)
		{
			swap(array[left], array[right]);
			++left;
			--right;
		}
	}
}

int main()
{
	srand(time(0));
	cout << "Enter length of array:" << endl;
	int length = 0;
	cin >> length;
	int *array1 = new int[length] {};
	int *array2 = new int[length] {};
	for (int i = 0; i < length - 1; ++i)
	{
		array1[i] = rand() % 10;
		array2[i] = rand() % 20 + 10;
	}
	cout << "First input:" << endl;
	printArray(array1, length);
	leftRight(array1, length);
	cout << "output:" << endl;
	printArray(array1, length);
	cout << endl << "Second input:" << endl;
	printArray(array2, length);
	leftRight(array2, length);
	cout << "output:" << endl;
	printArray(array2, length);
	delete[] array1;
	delete[] array2;
	return EXIT_SUCCESS;
}

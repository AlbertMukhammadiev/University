// task_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

void bubbleSort(int array[], int length)
{
	for (int i = 0; i < length - 1; ++i)
	{
		for (int j = 0; j < length - i - 1; ++j)
			if (array[j + 1] < array[j])
			{
				int temp = array[j];
				array[j] = array[j + 1];
				array[j + 1] = temp;
			}
	}
}

void printArray(int array[], int length)
{
	for (int i = 0; i < length - 1; ++i)
	{
		cout << array[i] << " ";
	}
	cout << array[length - 1] << endl;
}


void countingSort(int array[], int length, int max)
{
	int *numberOfElements = new int[max + 1] {};
	for (int i = 0; i < length; ++i)
	{
		++numberOfElements[array[i]];
	}
	int k = 0;
	for (int i = 0; i <= max; ++i)
	{
		for (int j = 0; j < numberOfElements[i]; ++j)
		{
			array[k] = i;
			++k;
		}
	}
	delete[] numberOfElements;
}

int main()
{
	srand(time(0));
	cout << "enter the length of array, please " << endl;
	int length = 0;
	cin >> length;
	int *bubbleArray = new int[length] {};
	for (int i = 0; i < length; ++i)
	{
		bubbleArray[i] = rand() % 10 + 10;
	}
	cout << "Array for bubble sort:" << endl << "input:" << endl;
	printArray(bubbleArray, length);
	cout << "output:" << endl;
	bubbleSort(bubbleArray, length);
	printArray(bubbleArray, length);

	int *countArray = new int[length] {};
	int maxElement = 0;
	for (int i = 0; i < length; ++i)
	{
		countArray[i] = rand() % 10;
		if (countArray[i] > maxElement)
			maxElement = countArray[i];
	}
	cout << endl << "Array for counting sort:" << endl << "input:" << endl;
	printArray(countArray, length);
	cout << "output:" << endl;
	countingSort(countArray, length, maxElement);
	printArray(countArray, length);
	delete[] bubbleArray;
	delete[] countArray;
	return EXIT_SUCCESS;
}
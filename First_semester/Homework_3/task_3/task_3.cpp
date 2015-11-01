// task_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <ctime>

using namespace std;

void insertSort(int array[], int left, int right)
{
	for (int i = left + 1; i <= right; ++i)
	{
		for (int j = i; j > left; --j)
		{
			if (array[j] < array[j - 1])
			{
				swap(array[j], array[j - 1]);
			}
			else
				break;
		}
	}
}

void quickSort(int array[], int left, int right)
{
	if (right - left <= 10)
	{
		insertSort(array, left, right);
		return;
	}
	int referencecell = array[left + (right - left) / 2];
	int i = left;
	int j = right;
	while (i <= j)
	{
		while (array[i] < referencecell)
			++i;
		while (array[j] > referencecell)
			--j;
		if (i <= j)
		{
			swap(array[i], array[j]);
			++i;
			--j;
		}
	}
	if (i < right)
	{
		quickSort(array, i, right);
	}
	if (left < j)
	{
		quickSort(array, left, j);
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

int frequentElement(int array[], int length)
{
	int maxCount = 0;
	int count = 0;
	int element = 0;
	for (int i = 1; i < length; ++i)
	{
		if (array[i - 1] == array[i])
		{
			++count;
			if (count > maxCount)
			{
				maxCount = count;
				element = array[i];
			}
		}
		else if (array[i - 1] != array[i])
		{
			count = 0;
		}
	}
	return element;
}

int main()
{
	srand(time(0));
	cout << "Enter the length of array:" << endl;
	int length = 0;
	cin >> length;
	int *array = new int[length];
	for (int i = 0; i < length; ++i)
	{
		array[i] = rand() % 20;
	}
	printArray(array, length);
	quickSort(array, 0, length - 1);
	printArray(array, length);
	cout << "the most frequent element of array is " << frequentElement(array, length) << endl;
	delete[] array;
	return EXIT_SUCCESS;
}

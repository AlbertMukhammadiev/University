// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
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
		insertSort(array, 0, right);
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

bool binarySearch(int array[], int left, int right, int number)
{
	if (left > right)
		return false;
	int midPoint = (left + right) / 2;
	if (array[midPoint] == number)
		return true;
	if (number < array[midPoint])
	{
		return binarySearch(array, left, midPoint - 1, number);
	}
	if (number > array[midPoint])
	{
		return binarySearch(array, midPoint + 1, right, number);
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

int main()
{
	srand(time(0));
	cout << "write number 1 <= n <= 5000, please:" << endl;
	int n = 0;
	cin >> n;
	int *array = new int[n] {};
	for (int i = 0; i < n; ++i)
	{
		array[i] = rand() % 100;
	}
	printArray(array, n);
	quickSort(array, 0, n - 1);
	printArray(array, n);
	cout << endl << "write pls number 1 <= k <= 300000:" << endl;
	int k = 0;
	cin >> k;
	cout << endl;
	for (int i = 1; i <= k; ++i)
	{
		int number = 0;
		cout << "write " << i << " number of k numbers:" << endl;
		cin >> number;
		if (binarySearch(array, 0, n - 1, number))
			cout << "that number is element of array" << endl << endl;
		else
			cout << "There is no a such element in this array" << endl << endl;
	}
	delete[] array;
	return EXIT_SUCCESS;
}

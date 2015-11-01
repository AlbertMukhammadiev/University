// task_1.cpp: определяет точку входа для консольного приложения.
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
		insertSort(array, left, right);  //получается я что то возвращаю в Void, так правильно писать?
		return;                          //или лучше сменить поставить тип int или bool и возвращать уже 0?
	}
	int referenceCell = array[left + (right - left) / 2];
	int i = left;
	int j = right;
	while (i <= j)
	{
		while (array[i] < referenceCell)
			++i;
		while (array[j] > referenceCell)
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
		/*if (right - i > 10)
			quickSort(array, i, right);
		else
			insertSort(array, i, right);*/
	}
	if (left < j)
	{
		quickSort(array, left, j);
		/*if (j - left > 10)
			quickSort(array, left, j);
		else
			insertSort(array, left, j);*/
	}
}

int main()
{
	srand(time(0));
	cout << "Enter the length of array" << endl;
	int length = 0;
	cin >> length;
	int *array = new int[length] {};
	for (int i = 0; i < length; i++)
	{
		array[i] = rand() % 10;
	}
	for (int i = 0; i < length; i++)
	{
		cout << array[i] << " ";
	}
	cout << endl;
	quickSort(array, 0, length - 1);
	for (int i = 0; i < length - 1; i++)
	{
		cout << array[i] << " ";
	}
	cout << array[length - 1] << endl;
	delete[] array;
 	return EXIT_SUCCESS;
}
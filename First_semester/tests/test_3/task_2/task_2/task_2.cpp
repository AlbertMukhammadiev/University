// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <ctime>

using namespace std;

int main()
{
	srand(time(0));
	const int m = 5;
	const int n = 5;
	int array[m][n] = {};
	for (int i = 0; i < m; ++i)
	{
		for (int j = 0; j < n; ++j)
		{
			array[i][j] = rand() % 10;
			cout << array[i][j] << " ";
		}
		cout << endl;
	}
	int l = 0;
	int c = 0;
	const int size = m * n;
	int arrayOfSaddlePoints[size] = {};
	int index = 0;
	for (int i = 0; i < m; ++i)
	{
		for (int j = 0; j < n; ++j)
		{
			if (array[i][j] < array[i][c])
			{
				c = j;
			}
		}
		for (int k = 0; (k < m) && (k != i); ++k)
		{
			if (array[k][c] > array[i][c])
			{
				break;
			}
			else
			{
				arrayOfSaddlePoints[index] = array[i][c];
				++index;
			}
		}
	}
	cout << endl;
	for (int i = 0; i < size; ++i)
	{
		if (arrayOfSaddlePoints[i] != 0)
		{
			cout << arrayOfSaddlePoints[i] << " ";
		}
	}
	return EXIT_SUCCESS;
}


// task_5.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

void reverse(int first, int length, int array[])
{
	for (int i = first, j = 0; j <= (length - first) / 2; ++i, ++j)
	{
		int temp = array[i];
		array[i] = array[length - j];
		array[length - j] = temp;
	}
}

int main()
{
	cout << "Enter the size of first part of array(variable m)" << endl;
	int m = 0;
	cin >> m;
	cout << "Enter the size of second part of array(variable n)" << endl;
	int n = 0;
	cin >> n;
	int *array = new int[m + n] {};
	cout << "enter array, please" << endl;
	for (int i = 0; i < (m + n); ++i)
		cin >> array[i];
	reverse(0, m - 1, array);
	reverse(m, m + n - 1, array);
	reverse(0, m + n - 1, array);
	cout << "result:" << endl;
	for (int i = 0; i < (m + n - 1); ++i)
		cout << array[i] << " ";
	cout << array[m + n - 1] << endl;
	delete[] array;
	return EXIT_SUCCESS;
}
// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <ctime>
#include <fstream>
#include "quickSort.h"
#include "frequentElement.h"

using namespace std;

void printArray(int array[], int length)
{
	ofstream fout("output.txt");
	for (int i = 0; i < length - 1; ++i)
	{
		fout << array[i] << " ";
		cout << array[i] << " ";
	}
	fout << array[length - 1] << endl;
	cout << array[length - 1] << endl;
	fout.close();
}

int main()
{
	setlocale(0, "");
	ifstream fin("input.txt");
	int numberOfBlanks = 0;
	if (!fin.is_open())
		cout << "Файл не может быть открыт!" << endl;
	else
	{
		while (!fin.eof())
		{
			if (fin.get() == ' ')
				++numberOfBlanks;
		}
	}
	fin.close();
	int *array = new int[numberOfBlanks + 1] {};
	fin.open("input.txt");
	if (!fin.is_open())
		cout << "Файл не может быть открыт!" << endl;
	else
	{
		for (int i = 0; i < numberOfBlanks + 1; ++i)
		{
			fin >> array[i];
		}
		printArray(array, numberOfBlanks + 1);
		quickSort(array, 0, numberOfBlanks);
		printArray(array, numberOfBlanks + 1);
		fin.close();
		cout << "The most often element of array is " << frequentElement(array, numberOfBlanks + 1) << endl;
	}
	delete[] array;
	return EXIT_SUCCESS;
}
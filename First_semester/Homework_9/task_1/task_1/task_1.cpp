// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>
#include "list.h"
#include "hash.h"

using namespace std;

int main()
{
	const int sizeOfHashTable = 19;
	List *array[sizeOfHashTable] = { nullptr };
	createHashTable(array, sizeOfHashTable);

	ifstream fin("text.txt");
	string word = "";
	if (!fin.is_open())
		cout << "File can't be opened" << endl;
	else
	{
		while (!fin.eof())
		{
			fin >> word;
			addNewElement(word, array[hashFunction(word, sizeOfHashTable)]);
		}
	}
	fin.close();

	printHashTable(array, sizeOfHashTable);
	deleteHashTable(array, sizeOfHashTable);
	return EXIT_SUCCESS;
}
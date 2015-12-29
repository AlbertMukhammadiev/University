// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>
#include "hash.h"

using namespace std;

int main()
{
	cout << "enter please size of hash table preferably a Prime number" << endl;
	int sizeOfHashTable = 0;
	cin >> sizeOfHashTable;
	List **hashTable = createHashTable(sizeOfHashTable);
	ifstream fin("text.txt");
	string word = "";
	if (!fin.is_open())
		cout << "File can't be opened" << endl;
	else
	{
		while (!fin.eof())
		{
			fin >> word;
			addElementToTable(word, hashTable, sizeOfHashTable);
		}
	}
	fin.close();

	printHashTable(hashTable, sizeOfHashTable);
	deleteHashTable(hashTable, sizeOfHashTable);
	return EXIT_SUCCESS;
}
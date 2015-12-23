// task_1_mergesort.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <fstream>
#include "listOfRecords.h"
#include "mergeSort(Bottom-up).h"
#include <string>

using namespace std;

int main()
{
	ifstream fin("phoneBook.txt");
	string buffer = "";
	List *listOfRecords = createList();
	int numberOfRecords = 1;
	if (!fin.is_open())
		cout << "File can't be opened" << endl;
	else
	{
		while (!fin.eof())
		{
			getline(fin, buffer);
			addNewRecord(buffer, listOfRecords, numberOfRecords);
		}
	}
	fin.close();
	printList(listOfRecords);

	cout << "Choose a field by which it is necessary to sort the list:" << endl
		<< "	-if you want to sort by name, push 1" << endl
		<< "	-if you want to sort by phone number, push 0" << endl
		<< "	your command is: ";
	bool field = false;
	cin >> field;
	mergeSort(listOfRecords, numberOfRecords, field);
	printList(listOfRecords);
	deleteList(listOfRecords);
	delete listOfRecords;
	return EXIT_SUCCESS;
}
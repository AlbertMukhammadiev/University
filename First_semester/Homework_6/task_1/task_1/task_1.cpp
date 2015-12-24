// task_1_telephone_directory.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <fstream>
#include <iostream>
#include "list.h"
#include "telephoneRecord.h"
#include "searchByField.h"

using namespace std;

int main()
{
	ifstream fin("file.txt");
	string buffer;
	TelephoneRecord x;
	List *listOfRecords = createList();
	if (!fin.is_open())
		cout << " File can't be opened" << endl;
	else
	{
		int i = 1;
		while (!fin.eof())
		{
			fin >> buffer;
			if (i == 1)
			{
				x.surname = buffer;
			}
			if (i == 2)
			{
				x.name = buffer;
			}
			if (i == 3)
			{
				x.phoneNumber = buffer;
				i = 0;
				addListElement(x, listOfRecords);
			}
			++i;
		}
	}
	fin.close();
	cout << " List from the file:" << endl;;
	printList(listOfRecords);

	cout << endl << " Enter one of these commands" << endl << "	0 - Exit" << endl
		<< "	1 - add telephone record(surname, name, number of the telephone)" << endl
		<< "	2 - search phone number using surname" << endl << "	3 - search surname using telephone number"
		<< endl << "	4 - save data base" << endl;

	int command = 5;
	cout << endl << " Enter the command, please:  ";
	cin >> command;
	while (command != 0)
	{
		switch (command)
		{
		case 1:
		{
			cout << "	-Enter surname, please:  ";
			cin >> buffer;
			x.surname = buffer;
			cout << "	-Enter  name,   please:  ";
			cin >> buffer;
			x.name = buffer;
			cout << "	-Enter   phone  number:  ";
			cin >> buffer;
			x.phoneNumber = buffer;
			addListElement(x, listOfRecords);
			break;
		}
		case 2:
		{
			cout << "	-Enter surname, please:  ";
			cin >> buffer;
			searchPhoneNumber(buffer, listOfRecords);
			break;
		}
		case 3:
		{
			cout << "	-Enter   phone  number:  ";
			cin >> buffer;
			searchName(buffer, listOfRecords);
			break;
		}
		case 4:
		{
			printToFile(listOfRecords);
			break;
		}
		}
		cout << endl << " Enter the command, please:  ";
		cin >> command;
	}

	printList(listOfRecords);
	deleteList(listOfRecords);
	return EXIT_SUCCESS;
}
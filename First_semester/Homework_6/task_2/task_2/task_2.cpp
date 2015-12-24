// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include "list.h"

using namespace std;

int main()
{
	List *list = createList();
	cout << " List of the commands:" << endl << "	0 - exit" << endl
		<< "	1 - add value in sorted list" << endl << "	2 - remove value from list" << endl
		<< "	3 - print list" << endl << endl << "-Enter the command, please: ";
	char command = '\0';
	cin >> command;
	while (command != '0')
	{
		switch (command)
		{
		case '1':
		{
			cout << "	Enter the letter please: ";
			Value letter = '\0';
			cin >> letter;
			addNewElement(letter, list);
			break;
		}
		case '2':
		{
			cout << "	Enter the letter please: ";
			Value letter = '\0';
			cin >> letter;
			deleteElement(letter, list);
			break;
		}
		case '3':
		{
			cout << "	List:" << endl;
			printList(list);
			break;
		}
		default:
		{
			cout << "-invalid command" << endl;
			break;
		}
		}
		cout << endl << "-Enter the command, please: ";
		cin >> command;
	}
	deleteList(list);
	return EXIT_SUCCESS;
}
// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <fstream>
#include "list.h"

using namespace std;

int main()
{
	ifstream fin("file.txt");
	int buffer = 0;
	List *listOfNaturalNumbers = createList();
	if (!fin.is_open())
		cout << "File can't be opened" << endl;
	else
	{
		while (!fin.eof())
		{
			fin >> buffer;
			addElementToHead(buffer, listOfNaturalNumbers);
		}
	}
	fin.close();
	printList(listOfNaturalNumbers);
	if (isSimmetrical(listOfNaturalNumbers))
	{
		cout << "list is simmetrical" << endl;
	}
	else
		cout << "list isn't simmetrical" << endl;

	deleteList(listOfNaturalNumbers);
	delete listOfNaturalNumbers;
	return EXIT_SUCCESS;
}
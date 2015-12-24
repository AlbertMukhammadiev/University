// task_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include "list.h"

using namespace std;

int main()
{
	List *listOfSicarii = createList();

	cout << "Enter the number of sicarii: ";
	int n = 0;
	cin >> n;
	while (n <= 1)
	{
		cout << endl << " ERROR. " << "Enter a number greater than 1: ";
		cin >> n;
	}

	createListOfSicarii(n, listOfSicarii);
	cout << endl << "List of sicarii:" << endl;
	printList(listOfSicarii);

	cout << endl << "Every m-th element will be removed from the list."
		<< endl << "Enter the sequence number m: ";
	int m = 0;
	cin >> m;
	while (m <= 1)
	{
		cout << endl << " ERROR. " << "Enter a number greater than 1: ";
		cin >> m;
	}
	cout << endl << "the sequence number of sikarius, who survived: "
		<< numberOfSurvivor(listOfSicarii, m) << endl;
	return EXIT_SUCCESS;
}
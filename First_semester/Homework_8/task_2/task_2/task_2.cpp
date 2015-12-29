// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include "binaryTree.h"

using namespace std;

int main()
{
	Tree *tree = createTree();
	cout << " List of the commands:" << endl << "	0 - exit" << endl
		<< "	1 - to add a value to the list" << endl
		<< "	2 - delete the node with the given key" << endl
		<< "	3 - verification of the existence of the node with the given key" << endl
		<< "	4 - print the keys of the tree in ascending order" << endl
		<< "	5 - print the keys of the tree in descending order" << endl
		<< "-Enter the command, please: ";
	char command = '0';
	cin >> command;
	while (command != '0')
	{
		switch (command)
		{
		case '1':
		{
			cout << "	Enter the key please: ";
			Key key = 0;
			cin >> key;
			cout << "	Enter the value please: ";
			Value value = 0;
			cin >> value;
			insert(value, key, tree);
			break;
		}
		case '2':
		{
			cout << "	Enter the key please: ";
			Key key = 0;
			cin >> key;
			remove(key, tree);
			break;
		}
		case '3':
		{
			cout << "	Enter the key please: ";
			Key key = 0;
			cin >> key;
			if (isExist(key, tree))
			{
				cout << "the node with the given key exists in the tree" << endl;
			}
			else
			{
				cout << "there is no node with the given key in the tree" << endl;
			}
			break;
		}
		case '4':
		{
			printTree(tree, Ascending);
			break;
		}
		case '5':
		{
			printTree(tree, Descending);
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
	deleteTree(tree);
	return EXIT_SUCCESS;
}

/*insert(0, 39, tree);
insert(0, 14, tree);
insert(0, 2, tree);
insert(0, 6, tree);
insert(0, 99, tree);
insert(0, 46, tree);
insert(0, 21, tree);
insert(0, 10, tree);
insert(0, 48, tree);
insert(0, 31, tree);
insert(0, 65, tree);
insert(0, 24, tree);*/
// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <fstream>
#include "KMPalgorithm.h"

using namespace std;

int main()
{
	cout << "Enter the string, please:" << endl;
	char string[1000] = {};
	char buffer = getchar();
	int i = 0;
	while ((buffer != EOF) && (buffer != '\n'))
	{
		string[i] = buffer;
		buffer = getchar();
		++i;
	}
	int lengthOfString = i;
	string[i] = '#';

	ifstream fin("text.txt");
	if (!fin.is_open())
		cout << "File can't be opened" << endl;
	else
	{
		buffer = fin.get();
		while (!fin.eof())
		{
			++i;
			string[i] = buffer;
			buffer = fin.get();
		}
	}
	fin.close();
	
	++i;
	int *prefix = new int[i] { 0 };
	prefixFunction(string, i, prefix);
	i = position(prefix, lengthOfString, i);
	if (i == 0)
	{
		cout << "there is no string in thei text" << endl;
	}
	else
	{
		cout << "position of the first occurrence of substring in string = " << i << endl;
	}
	delete prefix;
	return EXIT_SUCCESS;
}


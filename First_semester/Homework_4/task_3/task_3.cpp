// task_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <fstream>
#include <iostream>

using namespace std;

int main()
{
	ifstream fin("file.txt");
	int numOfNonemptyStrings = 0;
	char buffer[100] = {};
	if (!fin.is_open())
		cout << "Файл не может быть открыт!" << endl;
	else
	{
		char buff = '\0';
		while (!fin.eof())
		{
			fin.get(buff);
			bool isStringEmpty = true;
			while ((buff != '\n') && (!fin.eof()))
			{
				
				if ((buff != '\t') && (buff != ' '))
				{
					fin.getline(buffer, 100);
					isStringEmpty = false;
					break;
				}
				fin.get(buff);
			}
			if (!isStringEmpty)
			{
				++numOfNonemptyStrings;
			}
		}
	}
	fin.close();
	cout << "Number of nonempty strings " << numOfNonemptyStrings << endl;
	return EXIT_SUCCESS;
}


// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <fstream>
#include "date.h"

using namespace std;

int main()
{
	ifstream fin("input.txt");
	int buffer = 0;
	Date *date = createDate();
	Date *maxDate = createDate();

	if (!fin.is_open())
		cout << "File can't be opened" << endl;
	else
	{
		while (!fin.eof())
		{
			for (int i = 1; i <= 3; ++i)
			{
				fin >> buffer;
				
				///if the date is incorrect
				if (i == 1)
				{
					if ((buffer > 31) || (buffer < 1))
					{
						///skip this incorrect date
						fin.get();
						fin >> buffer;
						fin.get();
						fin >> buffer;
						fin.get();
						break;
					}
				}
				if (i == 2)
				{
					if ((buffer > 12) || (buffer < 1))
					{
						///skip this incorrect date
						fin.get();
						fin >> buffer;
						fin.get();
						break;
					}
				}

				///the reading point or line feed character
				fin.get();
				fillingDate(date, i, buffer);
			}
			comparingDates(maxDate, date);
		}
	}
	fin.close();
	cout << "the latest date:";
	printDate(maxDate);
	cout << endl;
	delete maxDate;
	delete date;
	return EXIT_SUCCESS;
}
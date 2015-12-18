// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include "convertToDecimal.h"

using namespace std;

int main()
{
	bool string[32] = {};
	cout << "Enter a number in binary notation, please" << endl;
	char buffer = getchar();
	int numberOfDigits = 0;
	for (int i = 0; (buffer != EOF) && (i < 32) && (buffer != '\n'); ++i)
	{
		if ((buffer != '1') && (buffer != '0'))
		{
			cout << "the entry is incorrect" << endl
				<< "enter the correct record of binary number" << endl;
			return EXIT_FAILURE;
		}
		if (buffer == '1')
		{
			string[i] = 1;
		}
		buffer = getchar();
		++numberOfDigits;
	}

	int result = convertToDecimal(string, numberOfDigits);
	cout << "result = " << result << endl;
	return EXIT_SUCCESS;
}
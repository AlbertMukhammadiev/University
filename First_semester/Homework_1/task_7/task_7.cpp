// task_7.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int main()
{
	cout << "Enter the string, please" << endl;
	char string[1000] = {};
	cin >> string;
	int i = 0;
	int indicator = 0;
	while (string[i] != '\0')
	{
		if (string[i] == '(')
			++indicator;
		else if (string[i] == ')')
			--indicator;
		if (indicator < 0)
		{
			cout << "Rule is violated" << endl;
			break;
		}
		++i;
	}
	if (indicator > 0)
		cout << "Opening parenthesis is greater than the closing" << endl;
	else if (indicator == 0)
		cout << "OK" << endl;
	return EXIT_SUCCESS;
}

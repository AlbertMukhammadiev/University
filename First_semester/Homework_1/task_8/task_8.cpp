// task_8.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int main()
{
	char s[1000] = {};
	cout << "Enter first string, please" << endl;
	cin >> s;
	char s1[1000] = {};
	cout << "Enter second string, please" << endl;
	cin >> s1;
	int i = 0;
	int j = 0;
	int numberOfSubstrings = 0;
	while (s[i] != '\0')
	{
		j = 0;
		while (s1[j] != '\0')
		{
			if (s[i + j] != s1[j])
				break;
			++j;
		}
		if (s1[j] == '\0')
			++numberOfSubstrings;
		++i;
	}
	cout << "The number of occurrences of a substrings in a string = " << numberOfSubstrings << endl;
	return EXIT_SUCCESS;
}

// task_4.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int main()
{
	cout << "Enter two numbers, please:" << endl;
	int a = 0;
	int b = 0;
	cin >> a >> b;
	int incompleteQuotient = 1;
	if (b == 0)
	{
		cout << "ERROR" << endl;
		return 1;
	}
	else if (a == 0)
	{
		incompleteQuotient = 0;
		cout << "result = " << incompleteQuotient;
		return 0;
	}
	else if (b == 1)
	{
		incompleteQuotient = a;
		cout << "result = " << incompleteQuotient;
		return 0;
	}
	else if (b == -1)
	{
		incompleteQuotient = a * (-1);
		cout << "result = " << incompleteQuotient;
		return 0;
	}
	else if (a == b)
	{
		cout << "result = " << incompleteQuotient;
		return 0;
	}
	else if (a == (b * -1))
	{
		incompleteQuotient = -1;
		cout << "result = " << incompleteQuotient;
		return 0;
	}
	bool aPozitive = true;
	if (a < 0)
	{
		aPozitive = false;
		a = abs(a);
	}
	bool bPozitive = true;
	if (b < 0)
	{
		bPozitive = false;
		b = abs(b);
	}
	if (a < b)
	{
		if (aPozitive)
			incompleteQuotient = 0;
		else if (!aPozitive)
		{
			if (bPozitive)
				incompleteQuotient = -1;
			else if (!bPozitive)
				incompleteQuotient = 1;
		}
	}
	else if (a > b)
	{
		int temp = a - b;
		while ((incompleteQuotient + 1) * b <= a)
		{
			++incompleteQuotient;
			temp = temp - b;
		}
		if (aPozitive)
		{
			if (!bPozitive)
				incompleteQuotient = incompleteQuotient * -1;
		}
		else if (!aPozitive)
		{
			if (temp != 0)
				++incompleteQuotient;
			if (bPozitive)
				incompleteQuotient = -1 * incompleteQuotient;
		}
	}
	if (b != 0)
		cout << "result = " << incompleteQuotient << endl;
	return EXIT_SUCCESS;
}
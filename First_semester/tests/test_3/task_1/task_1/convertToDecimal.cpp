#include "stdafx.h"
#include "convertToDecimal.h"

int convertToDecimal(bool string[], int numberOfDigits)
{
	int degTwo = 1;
	int number = 0;
	for (int i = numberOfDigits - 1; i >= 0; --i)
	{
		if (string[i] == 1)
		{
			number += degTwo;
		}
		degTwo = degTwo * 2;
	}
	return number;
}
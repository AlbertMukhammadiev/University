#include "stdafx.h"
#include <iostream>
#include "KMPalgorithm.h"

void prefixFunction(char string[], int sizeOfString, int prefix[])
{
	prefix[0] = 0;
	for (int i = 1; i < sizeOfString; ++i)
	{
		int j = prefix[i - 1];
		while ((j > 0) && (string[j] != string[i]))
		{
			j = prefix[j - 1];
		}
		if (string[i] == string[j])
		{
			++j;
		}
		prefix[i] = j;
		std::cout << prefix[i];
	}
}

int position(int prefix[], int lengthOfString, int lengthOfText)
{
	for (int i = lengthOfString + 1; i < lengthOfText; ++i)
	{
		if (prefix[i] == lengthOfString)
		{
			return i - 2 * lengthOfString;
		}
	}
	return -1;
}
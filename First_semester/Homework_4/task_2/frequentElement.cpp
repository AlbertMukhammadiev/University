#include "stdafx.h"
#include "frequentElement.h"

int frequentElement(int array[], int length)
{
	int maxCount = 0;
	int count = 0;
	int element = 0;
	for (int i = 1; i < length; ++i)
	{
		if (array[i - 1] == array[i])
		{
			++count;
			if (count > maxCount)
			{
				maxCount = count;
				element = array[i];
			}
		}
		else if (array[i - 1] != array[i])
		{
			count = 0;
		}
	}
	return element;
}
#include "stdafx.h"
#include "quickSort.h"

void insertSort(int array[], int left, int right)
{
	for (int i = left + 1; i <= right; ++i)
	{
		for (int j = i; j > left; --j)
		{
			if (array[j] < array[j - 1])
			{
				array[j] = array[j] ^ array[j - 1];
				array[j - 1] = array[j] ^ array[j - 1];
				array[j] = array[j] ^ array[j - 1];
			}
			else
				break;
		}
	}
}

void quickSort(int array[], int left, int right)
{
	if (right - left <= 10)
	{
		insertSort(array, left, right);
		return;
	}
	int referencecell = array[left + (right - left) / 2];
	int i = left;
	int j = right;
	while (i <= j)
	{
		while (array[i] < referencecell)
			++i;
		while (array[j] > referencecell)
			--j;
		if (i <= j)
		{
			if (i != j)
			{
				array[i] = array[i] ^ array[j];
				array[j] = array[i] ^ array[j];
				array[i] = array[i] ^ array[j];
			}
			++i;
			--j;
		}
	}
	if (i < right)
	{
		quickSort(array, i, right);
	}
	if (left < j)
	{
		quickSort(array, left, j);
	}
}
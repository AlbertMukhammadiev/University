#include "stdafx.h"
#include "listOfRecords.h"
#include "mergeSort(Bottom-up).h"

void mergeSort(List *list, int sizeOfList, bool field)
{
	int sizeOfSublist = 1;
	int remaining = 0;
	int carriage = 0;
	List *buffer = createBuffer();
	while (sizeOfSublist < sizeOfList)
	{
		carriage = 0;
		Position first = head(list);
		Position second = head(list);
		while (carriage < sizeOfList)
		{
			if (carriage + sizeOfSublist >= sizeOfList)
				break;

			remaining = (carriage + sizeOfSublist * 2 > sizeOfList) ? (sizeOfList - (carriage + sizeOfSublist)) : sizeOfSublist;

			second = first;
			for (int i = 0; i < sizeOfSublist; ++i)
			{
				second = next(second);
			}

			merge(buffer, first, second, sizeOfSublist, field);

			Position j = head(buffer);
			for (int k = 0; k < sizeOfSublist + remaining; ++k)
			{
				copyValue(first, j);
				first = next(first);
				j = next(j);
			}
			carriage = sizeOfSublist * 2 + carriage;
		}
		sizeOfSublist *= 2;
	}
	deleteList(buffer);
	delete buffer;
}

void merge(List *buffer, Position first, Position second, int sizeOfSublist, bool field)
{
	Position i = head(buffer);
	int firstSublist = sizeOfSublist;
	int secondSublist = sizeOfSublist;

	while ((secondSublist > 0) || (firstSublist > 0))
	{
		if ((getValue(first, field) <= getValue(second, field)) && (firstSublist > 0)
			|| (secondSublist == 0))
		{
			copyValue(i, first);
			--firstSublist;
			first = next(first);
		}
		else if ((getValue(first, field) > getValue(second, field)) && (secondSublist > 0)
			|| (firstSublist == 0))
		{
			copyValue(i, second);
			--secondSublist;
			second = next(second);
		}

		if (!next(i))
		{
			increaseBuffer(i);
		}

		i = next(i);

		///if the second sublist is ended
		if (!second)
		{
			while (firstSublist > 0)
			{
				copyValue(i, first);
				--firstSublist;
				first = next(i);
				if (!next(i))
				{
					increaseBuffer(i);
				}
				i = next(i);
			}
			return;
		}
	}
}
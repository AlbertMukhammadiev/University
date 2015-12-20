#include "stdafx.h"
#include "telephoneRecord.h"

void copy(char buffer[], char field[])
{
	int i = 0;
	while (buffer[i] != '\0')
	{
		field[i] = buffer[i];
		++i;
	}

	for (int j = i; j < 15; ++j)
	{
		field[j] = '\0';
	}
}
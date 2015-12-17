#include "stdafx.h"
#include <iostream>
#include "date.h"

struct Date
{
	int day = 0;
	int month = 0;
	int year = 0;
};

Date *createDate()
{
	Date *date = new Date;
	return date;
}

void fillingDate(Date *date, int numberOfField, int buffer)
{
	if (numberOfField == 1)
	{
		date->day = buffer;
		return;
	}
	if (numberOfField == 2)
	{
		date->month = buffer;
		return;
	}
	if (numberOfField == 3)
	{
		date->year = buffer;
		return;
	}
}

void comparingDates(Date *maxDate, Date *newDate)
{
	if (maxDate->year < newDate->year)
	{
		maxDate->day = newDate->day;
		maxDate->month = newDate->month;
		maxDate->year = newDate->year;
		return;
	}
	else if (maxDate->year > newDate->year)
	{
		return;
	}
	else if (maxDate->year == newDate->year)
	{
		if (maxDate->month < newDate->month)
		{
			maxDate->day = newDate->day;
			maxDate->month = newDate->month;
			maxDate->year = newDate->year;
			return;
		}

		else if (maxDate->month > newDate->month)
		{
			return;
		}

		else if (maxDate->month == newDate->month)
		{
			if (maxDate->day < newDate->day)
			{
				maxDate->day = newDate->day;
				maxDate->month = newDate->month;
				maxDate->year = newDate->year;
				return;
			}
			else
			{
				return;
			}
		}
	}
}

void printDate(Date *date)
{
	if (date->day / 10 < 1)
	{
		std::cout << '0';
	}
	std::cout << date->day << '.';
	if (date->month / 10 < 1)
	{
		std::cout << '0';
	}
	std::cout << date->month << '.';
	if (date->year < 0)
	{
		date->year = date->year * -1;
		std::cout << date->year << " B.C." << std::endl;
	}
	else
	{
		std::cout << date->year << std::endl;
	}
}
#include "stdafx.h"
#include <iostream>
#include "searchByField.h"

void searchPhoneNumber(const std::string &buffer, List *listOfRecords)
{
	Position i = head(listOfRecords);
	while (i) {
		if (getSurname(i) == buffer)
		{
			std::cout << "	# Phone number of this man: "
				<< getPhoneNumber(i) << std::endl;
			return;
		}
		i = next(i);
	}
	std::cout << "	# No man with such surname" << std::endl;
}

void searchName(const std::string &buffer, List *listOfRecords)
{
	Position i = head(listOfRecords);
	while (i) {
		if (getPhoneNumber(i) == buffer)
		{
			std::cout << "	# Name and surname of man with this phone number: "
				<< getName(i) << " " << getSurname(i) << std::endl;
			return;
		}
		i = next(i);
	}
	std::cout << "	# No man with such phone number" << std::endl;
}
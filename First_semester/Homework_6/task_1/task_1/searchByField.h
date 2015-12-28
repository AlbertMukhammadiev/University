#pragma once
#include "list.h"
#include "telephoneRecord.h"

/// prints to the console the phone number of the person with this surname
void searchPhoneNumber(const std::string &buffer, List *listOfRecords);

/// prints to the console the name and surname of the person with this phone number
void searchName(const std::string &buffer, List *listOfRecords);
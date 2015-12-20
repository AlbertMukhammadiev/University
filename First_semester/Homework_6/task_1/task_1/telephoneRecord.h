#pragma once

struct TelephoneRecord
{
	char surname[15] = { '\0' };
	char name[15] = { '\0' };
	char phoneNumber[15] = { '\0' };
};

void copy(char buffer[], char field[]);
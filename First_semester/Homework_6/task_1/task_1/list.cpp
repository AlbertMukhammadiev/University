#include "stdafx.h"
#include <iostream>
#include <fstream>
#include "list.h"
#include "telephoneRecord.h"

struct ListElement
{
	TelephoneRecord value;
	ListElement *next = nullptr;
};

struct List
{
	ListElement *head = nullptr;
};

List *createList()
{
	List *list = new List();
	return list;
}

void addListElement(TelephoneRecord record, List *listOfRecords)
{
	Position newElement = new ListElement;
	newElement->value = record;
	newElement->next = listOfRecords->head;
	listOfRecords->head = newElement;
}

void printToFile(List *listOfRecords)
{
	std::ofstream fout("output.txt");
	if (listOfRecords->head == nullptr)
	{
		fout << "	# List is empty" << std::endl;
	}
	else
	{
		Position i = listOfRecords->head;
		while (i)
		{
			fout << i->value.name << " " << i->value.surname << " " << i->value.phoneNumber << std::endl;
			i = i->next;
		}
	}
	fout.close();
}

void printList(List *listOfRecords)
{
	if (listOfRecords->head == nullptr)
	{
		std::cout << "	# List is empty" << std::endl;
	}
	else
	{
		Position i = listOfRecords->head;
		while (i)
		{
			std::cout << "	" << i->value.name << " " << i->value.surname << " " << i->value.phoneNumber << std::endl;
			i = i->next;
		}
	}
}

void deleteList(List *list)
{
	Position temp = nullptr;
	while (list->head)
	{
		temp = list->head->next;
		delete list->head;
		list->head = temp;
	}
}

void searchPhoneNumber(char buffer[], List *listOfRecords)
{
	ListElement* i = listOfRecords->head;
	while (i) {
		if (strcmp(i->value.surname, buffer) == 0)
		{
			std::cout << "	# Phone number of this man: " << i->value.phoneNumber << std::endl;
			return;
		}
		i = i->next;
	}
	std::cout << "	# No man with such surname" << std::endl;
}

void searchName(char buffer[], List *listOfRecords)
{
	ListElement* i = listOfRecords->head;
	while (i) {
		if (strcmp(i->value.phoneNumber, buffer) == 0)
		{
			std::cout << "	# Name and surname of man with this phone number: " << i->value.name << " " << i->value.surname << std::endl;
			return;
		}
		i = i->next;
	}
	std::cout << "	# No man with such phone number" << std::endl;
}
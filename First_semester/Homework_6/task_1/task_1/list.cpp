#include "stdafx.h"
#include <iostream>
#include <fstream>
#include "list.h"

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
	return new List();
}

Position head(List *list)
{
	return list->head;
}

Position next(Position element)
{
	return element->next;
}

std::string getSurname(Position element)
{
	return element->value.surname;
}

std::string getPhoneNumber(Position element)
{
	return element->value.phoneNumber;
}

std::string getName(Position element)
{
	return element->value.name;
}

void addListElement(const TelephoneRecord &record, List *listOfRecords)
{
	Position newElement = new ListElement;
	newElement->value = record;

	if (!listOfRecords->head)
	{
		listOfRecords->head = newElement;
		return;
	}

	Position i = listOfRecords->head;
	while (i->next)
	{
		i = i->next;
	}
	i->next = newElement;
}

void printToFile(List *listOfRecords)
{
	std::ofstream fout("file.txt");
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
	delete list;
}
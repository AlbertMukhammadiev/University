#include "stdafx.h"
#include <iostream>
#include "listOfRecords.h"
#include <cmath>

struct ListElement
{
	std::string name = "";
	std::string phoneNumber = "";
	ListElement *next = nullptr;
};

struct List
{
	ListElement *head = nullptr;
	int size = 1;
};

List *createList()
{
	return new List;
}

List *createBuffer()
{
	List *buffer = new List();
	Position head = new ListElement;
	buffer->head = head;
	return buffer;
}

Position head(List *list)
{
	return list->head;
}

Position next(Position element)
{
	return element->next;
}

void copyValue(Position to, Position from)
{
	to->name = from->name;
	to->phoneNumber = from->phoneNumber;
}

std::string getValue(Position element, Field field)
{
	if (field == name)
	{
		return element->name;
	}
	else if (field == phoneNumber)
	{
		return element->phoneNumber;
	}
}

int getSize(List *list)
{
	return list->size;
}

void addNewRecord(const std::string value, List *list)
{
	std::string name = "";
	int j = 0;
	while (value[j] != '-')
	{
		name += value[j];
		++j;
	}
	++j;
	std::string phoneNumber = "";
	while (value[j] != '\0')
	{
		phoneNumber += value[j];
		++j;
	}

	Position newRecord = new ListElement;
	newRecord->name = name;
	newRecord->phoneNumber = phoneNumber;

	if (!list->head)
	{
		list->head = newRecord;
		return;
	}

	Position i = list->head;
	while (i->next)
	{
		i = i->next;
	}
	i->next = newRecord;
	++list->size;
}

void increaseBuffer(Position tail)
{
	Position element = new ListElement;
	tail->next = element;
}

void printList(List *list)
{
	if (list->head == nullptr)
	{
		std::cout << "	# List is empty" << std::endl;
	}
	else
	{
		Position record = list->head;
		while (record)
		{
			std::cout << record->name << " - " << record->phoneNumber << std::endl;
			record = record->next;
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
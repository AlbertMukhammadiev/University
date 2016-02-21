#include "stdafx.h"
#include <iostream>
#include "list.h"

struct ListElement
{
	Value value = '\0';
	ListElement *next = nullptr;
};

struct List
{
	Position head = nullptr;
};

List *createList()
{
	return new List();
}

void addNewElement(int value, List *listOfRecords)
{
	Position newElement = new ListElement;
	newElement->value = value;

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

void pop(List *list)
{
	if (!list->head)
	{
		std::cout << "	list is empty" << std::endl;
		return;
	}
	ListElement *temp = list->head;
	list->head = list->head->next;
	delete temp;
}

Value getValue(List *list)
{
	return list->head->value;
}

bool isEmpty(List *list)
{
	return list->head ? false : true;
}

void deleteList(List *list)
{
	while (list->head)
	{
		Position temp = list->head->next;
		delete list->head;
		list->head = temp;
	}
	delete list;
}
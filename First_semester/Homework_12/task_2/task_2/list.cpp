#include "stdafx.h"
#include <iostream>
#include "list.h"

struct ListElement
{
	Value value;
	ListElement *next = nullptr;
};

struct List
{
	Position head = nullptr;
};

List *createList()
{
	List *list = new List();
	return list;
}

void addNewElement(Value value, List *list)
{
	if (!list->head)
	{
		list->head = new ListElement;
		list->head->value = value;
		return;
	}
	else
	{

		//Add to head
		if (list->head->value.weight > value.weight)
		{
			Position temp = list->head;
			list->head = new ListElement;
			list->head->value = value;
			list->head->next = temp;
			return;
		}

		//Add to sort list
		Position i = list->head;
		while (i->next)
		{
			if (i->next->value.weight > value.weight)
			{
				break;
			}
			i = i->next;
		}

		Position newElement = new ListElement;
		newElement->value = value;
		newElement->next = i->next;
		i->next = newElement;
	}
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
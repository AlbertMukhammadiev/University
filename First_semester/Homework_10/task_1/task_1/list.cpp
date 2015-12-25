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
	List *l = new List();
	return l;
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
		if (list->head->value.sequenceNumber == value.sequenceNumber)
		{
			return;
		}

		//Add to head
		if (list->head->value.wayToCity > value.wayToCity)
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
			if (i->next->value.sequenceNumber == value.sequenceNumber)
			{
				return;
			}

			if (i->next->value.wayToCity > value.wayToCity)
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

void printList(List *list)
{
	std::cout << "	";
	if (list->head == nullptr)
	{
		std::cout << "-List is empty" << std::endl;
	}
	else
	{
		Position listElement = list->head;
		while (listElement)
		{
			printCity(listElement->value);
			listElement = listElement->next;
		}
		std::cout << std::endl;
	}
}

void deleteElement(Value value, List *list)
{
	if (!list->head)
	{
		std::cout << "	-List is empty" << std::endl;
		return;
	}

	if (list->head->value.sequenceNumber == value.sequenceNumber)
	{
		Position temp = list->head->next;
		delete list->head;
		list->head = temp;
		return;
	}

	Position i = list->head;
	while (i->next)
	{
		if (i->next->value.sequenceNumber == value.sequenceNumber)
		{
			Position temp = i->next->next;
			delete i->next;
			i->next = temp;
			return;
		}
		i = i->next;
	}
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
#include "stdafx.h"
#include <iostream>
#include "list.h"

struct ListElement
{
	Value value = "";
	int number = 0;
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
		Position newElement = new ListElement;
		newElement->value = value;
		++newElement->number;
		list->head = newElement;
		return;
	}
	else
	{
		if (list->head->value == value)
		{
			++list->head->number;
			return;
		}

		//Add to head
		if (list->head->value > value)
		{
			Position newElement = new ListElement;
			newElement->value = value;
			++newElement->number;
			
			Position temp = list->head;
			list->head = newElement;
			list->head->next = temp;
			return;
		}

		//Add to sort list
		Position i = list->head;
		while (i->next)
		{
			if (i->next->value == value)
			{
				++i->number;
				return;
			}

			if (i->next->value > value)
			{
				break;
			}
			i = i->next;
		}
		Position newElement = new ListElement;
		newElement->value = value;
		++newElement->number;

		newElement->next = i->next;
		i->next = newElement;
	}
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
			std::cout << listElement->value << "("
				<< listElement->number << ")" << " ";
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

	if (list->head->value == value)
	{
		Position temp = list->head->next;
		delete list->head;
		list->head = temp;
		return;
	}

	Position i = list->head;
	while (i->next)
	{
		if (i->next->value == value)
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
	Position temp = nullptr;
	while (list->head)
	{
		temp = list->head->next;
		delete list->head;
		list->head = temp;
	}
}

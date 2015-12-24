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
		if (list->head->value == value)
		{
			std::cout << "	This element is already present in the list" << std::endl;
			return;
		}

		//Add to head
		if (list->head->value > value)
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
			if (i->next->value == value)
			{
				std::cout << "	This element is already present in the list" << std::endl;
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
			std::cout << listElement->value << " ";
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
	while (list->head)
	{
		Position temp = list->head->next;
		delete list->head;
		list->head = temp;
	}
	delete list;
}
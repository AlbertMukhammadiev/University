#include "stdafx.h"
#include <iostream>
#include "list.h"

struct ListElement
{
	ListElement *previous;
	int value;
	ListElement *next;
};

struct List
{
	ListElement *head = nullptr;
	ListElement *tail = nullptr;
};

List *createList()
{
	List *list = new List();
	return list;
}

Position createNewElement()
{
	Position element = new ListElement();
	element->next = nullptr;
	element->previous = nullptr;
	element->value = 0;
	return element;
}

void addElementToHead(int value, List *list)
{
	Position element = createNewElement();
	if (!list->tail)
	{
		list->tail = element;
		list->head = element;
		element->value = value;
		return;
	}
	list->head->previous = element;
	element->next = list->head;
	element->value = value;
	list->head = element;
}

void printList(List *list)
{
	if (list->head == nullptr)
	{
		std::cout << "List is empty" << std::endl;
	}
	else
	{
		Position print = list->head;
		std::cout << "List of natural numbers:" << std::endl;
		while (print)
		{
			std::cout << print->value << " ";
			print = print->next;
		}
		std::cout << std::endl;
	}
}

bool isSimmetrical(List *list)
{
	Position left = list->head;
	Position right = list->tail;
	while (left != right)
	{
		if (left->value != right->value)
		{
			return false;
		}

		left = left->next;
		right = right->previous;
	}
	return true;
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
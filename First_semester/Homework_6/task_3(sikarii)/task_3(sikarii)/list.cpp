#include "stdafx.h"
#include <iostream>
#include "list.h"

struct ListElement
{
	Value value = 0;
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

////circular list using add to head
void createListOfSicarii(int number, List *list)
{
	Position lastSikarius = new ListElement;
	lastSikarius->value = number;
	list->head = lastSikarius;
	--number;

	for (int i = number; i > 0; --i)
	{
		Position sicarius = new ListElement;
		sicarius->value = i;
		Position temp = list->head;
		list->head = sicarius;
		list->head->next = temp;
	}
	//connect the head and the tail
	lastSikarius->next = list->head;
}

void printList(List *list)
{
	if (!list->head)
	{
		std::cout << "-List is empty" << std::endl;
	}
	else
	{
		Position listElement = list->head;
		Value headValue = list->head->value;
		while (listElement->next->value != headValue)
		{
			std::cout << listElement->value << " ";
			listElement = listElement->next;
		}
		std::cout << listElement->value << std::endl;
	}
}

Value numberOfSurvivor(List *list, int m)
{
	Position i = list->head;
	while (i->next->value != i->value)
	{
		if (!list->head)
		{
			std::cout << "	-List is empty" << std::endl;
			return 0;
		}

		//deletion of every m-th element
		for (int j = 1; j < m - 1; ++j)
		{
			i = i->next;
		}
		Position temp = i->next->next;
		delete i->next;
		i->next = temp;

		i = i->next;
	}
	Value value = i->value;
	delete i;
	list->head = nullptr;
	return value;
}
#pragma once

struct ListElement;

struct List;

struct Road
{
	int from = 0;
	int to = 0;
	int weight = 0;
};

typedef ListElement* Position;

typedef Road Value;

///creates the list and returns a pointer to the list
List *createList();

///adds a new value to the list(without disturbing order)
///(duplicate values are ignored)
void addNewElement(Value value, List *list);

///removes the head of the list
void pop(List *list);

///returns the value of the head of the list
Value getValue(List *list);

///checking list for emptiness
bool isEmpty(List *list);

void deleteList(List *list);
#pragma once
#include "city.h"

struct List;

struct ListElement;

typedef ListElement* Position;

typedef City Value;

///creates the list and returns a pointer to the list
List *createList();

///creates array of the list and returns a pointer to the array
List **createArrayOfLists(int size);

///adds a new value to the list(without disturbing order)
///(duplicate values are ignored)
void addNewElement(Value value, List *list);

///removes the head of the list
void pop(List *list);

///returns the value of the head of the list
Value getValue(List *list);

///removes the list item with the given value
void deleteElement(Value value, List *list);

///checking list for emptiness
bool isEmpty(List *list);

void printList(List *list);

void deleteList(List *list);

void deleteArrayOfLists(List **arrayOfLists, int size);
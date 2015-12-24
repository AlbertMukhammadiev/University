#pragma once

struct List;

struct ListElement;

typedef ListElement* Position;

typedef char Value;

List *createList();

///adds a new value to the list(without disturbing order)
///(duplicate values are ignored)
void addNewElement(Value value, List *list);

///removes the list item with the given value
void deleteElement(Value value, List *list);

void printList(List *list);

void deleteList(List *p);
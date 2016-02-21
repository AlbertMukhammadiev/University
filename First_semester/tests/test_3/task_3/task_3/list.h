#pragma once

struct List;

struct ListElement;

typedef ListElement* Position;

typedef int Value;

/// creates the list and returns pointer to it
List *createList();

/// adds a new value to the list
void addNewElement(Value value, List *list);

/// removes the head of the list
void pop(List *list);

/// returns the value of the head of the list
Value getValue(List *list);

/// checking list for emptiness
bool isEmpty(List *list);

void deleteList(List *p);
#pragma once
#include <string>

struct List;

struct ListElement;

typedef ListElement* Position;

typedef std::string Value;

/// creates a list and returns a pointer to it
List *createList();

/// adds a new value to the list(without disturbing order)
/// if the element with the given value already exists in the list, then count is incremented
void addNewElement(Value value, List *list);

/// removes the element with the given value from the list
void deleteElement(Value value, List *list);

/// displays entire list into the console
void printList(List *list);

/// deletes the entire list
void deleteList(List *p);
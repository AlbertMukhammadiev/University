#pragma once
#include <string>

struct ListElement;

struct List;

/// creates a list and returns a pointer to it
List *createList();

typedef ListElement* Position;

/// creates buffer with one element
List *createBuffer();

/// returns access to the head of list
Position head(List *list);

///access to the next list item
Position next(Position element);

/// copies the value of one item list to another
void copyValue(Position to, Position from);

enum Field
{
	name,
	phoneNumber
};

/// returns the phone number or the name depending on a Boolean variable
std::string getValue(Position element, Field field);

/// returns size of the list
int getSize(List *list);

/// adds a new record to the singly linked list
void addNewRecord(const std::string value, List *list);

/// increase the buffer size for one element
void increaseBuffer(Position tail);

/// displays entire list into the console
void printList(List *list);

/// deletes the entire list
void deleteList(List *list);
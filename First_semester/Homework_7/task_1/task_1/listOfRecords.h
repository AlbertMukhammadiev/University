#pragma once
#include <string>

struct ListElement;

struct List;

List *createList();

typedef ListElement* Position;

///create buffer with one element
List *createBuffer();

///access to the head of list
Position head(List *list);

///access to the next list item
Position next(Position element);

void copyValue(Position to, Position from);

///get the phone number or the name depending on a Boolean variable
std::string getValue(Position element, bool field);

void addNewRecord(std::string value, List *list, int &numberOfElements);

///increase the buffer size for one element
void increaseBuffer(Position tail);

void printList(List *list);

void deleteList(List *list);
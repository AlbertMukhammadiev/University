#pragma once
#include <string>
#include "telephoneRecord.h"

struct ListElement;

struct List;

///creates a singly linked list
List *createList();

typedef ListElement* Position;

///access to the head of list
Position head(List *list);

///access to the next list item
Position next(Position element);

std::string getSurname(Position element);

std::string getPhoneNumber(Position element);

std::string getName(Position element);

void printToFile(List *listOfRecords);

void addListElement(TelephoneRecord &record, List *listOfRecords);

void deleteList(List *list);

void printList(List *listOfRecords);
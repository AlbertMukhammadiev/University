#pragma once
#include <string>
#include "telephoneRecord.h"

struct ListElement;

struct List;

/// creates a singly linked list
List *createList();

typedef ListElement* Position;

/// access to the head of list
Position head(List *list);

/// access to the next list item
Position next(Position element);

/// returns surname of element->record
std::string getSurname(Position element);

/// returns phone number of element->record
std::string getPhoneNumber(Position element);

/// returns name of element->record
std::string getName(Position element);

/// prints telephone records to "file.txt"
void printToFile(List *listOfRecords);

/// adds telephone record to list(without sorting)
void addListElement(const TelephoneRecord &record, List *listOfRecords);

/// deletes the entire list
void deleteList(List *list);

/// displays entire list into the console
void printList(List *listOfRecords);
#pragma once
#include <string>
#include "telephoneRecord.h"

struct ListElement;

struct List;

List *createList();

typedef ListElement* Position;

Position head(List *list);

Position next(Position element);

std::string getSurname(Position element);

std::string getPhoneNumber(Position element);

std::string getName(Position element);

void printToFile(List *listOfRecords);

void addListElement(TelephoneRecord record, List *listOfRecords);

void deleteList(List *list);

void printList(List *listOfRecords);
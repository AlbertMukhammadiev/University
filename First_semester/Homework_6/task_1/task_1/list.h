#pragma once
#include "telephoneRecord.h"

struct ListElement;

struct List;

List *createList();

typedef ListElement* Position;

void searchPhoneNumber(char word[], List *listOfRecords);

void searchName(char word[], List *listOfRecords);

void printToFile(List *listOfRecords);

void addListElement(TelephoneRecord value, List *listOfRecords);

void deleteList(List *list);

void printList(List *listOfRecords);
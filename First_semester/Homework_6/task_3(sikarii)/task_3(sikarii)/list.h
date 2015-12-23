#pragma once

struct List;

struct ListElement;

typedef ListElement* Position;

typedef int Value;

List *createList();

void createListOfSicarii(int number, List *list);

Value numberOfSurvivor(List *list, int m);

void printList(List *list);
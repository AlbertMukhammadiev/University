#pragma once

struct List;

struct ListElement;

typedef ListElement* Position;

typedef int Value;

List *createList();

///circular list using add to head
void createListOfSicarii(int number, List *list);

///returns the number of survivors
///and frees the memory allocated for the list
Value numberOfSurvivor(List *list, int m);

void printList(List *list);
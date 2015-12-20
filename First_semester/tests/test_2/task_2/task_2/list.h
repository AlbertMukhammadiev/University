#pragma once

struct List;

struct ListElement;

typedef ListElement *Position;

void addElementToHead(int value, List *list);

List *createList();

Position createNewElement();

void printList(List *list);

bool isSimmetrical(List *listOfNaturalNumbers);

void deleteList(List *list);
#pragma once

struct List;

struct ListElement;

typedef ListElement* Position;

typedef char Value;

List *createList();

void addNewElement(Value value, List *list);

void deleteElement(Value value, List *list);

void printList(List *list);

void deleteList(List *p);
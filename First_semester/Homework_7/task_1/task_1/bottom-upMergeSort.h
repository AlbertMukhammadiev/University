#pragma once
#include <string>
#include "listOfRecords.h"

void mergeSort(List *list, int sizeOfList, Field field);

void merge(List* buffer, Position first, Position second, int sizeOfSublist, Field field);
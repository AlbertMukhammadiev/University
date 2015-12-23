#pragma once
#include <string>
#include "listOfRecords.h"

void mergeSort(List *list, int sizeOfSublist, bool field);

void merge(List* buffer, Position first, Position second, int sizeOfSublist, bool field);
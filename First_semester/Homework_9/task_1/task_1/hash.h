#pragma once
#include <string>
#include "list.h"

int hashFunction(std::string word, int sizeOfHashTable);

void createHashTable(List* array[], int sizeOfHashTable);

void printHashTable(List* array[], int sizeOfHashTable);

void deleteHashTable(List* array[], int sizeOfHashTable);
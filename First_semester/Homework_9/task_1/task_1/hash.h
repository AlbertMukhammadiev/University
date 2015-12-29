#pragma once
#include <string>
#include "list.h"

/// computes a hash function for a given word and returns it
int hashFunction(const std::string word, int sizeOfHashTable);

/// creates a hash table as an array of lists, and returns a pointer to this array
List **createHashTable(int sizeOfHashTable);

/// adds the word in the hash table
void addElementToTable(const std::string word, List **hashTable, int sizeOfHashTabdle);

/// displays the hash table into the console
void printHashTable(List* array[], int sizeOfHashTable);

/// deletes the entire hash table
void deleteHashTable(List* array[], int sizeOfHashTable);
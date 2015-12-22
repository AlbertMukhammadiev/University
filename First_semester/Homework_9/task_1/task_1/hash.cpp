#include "stdafx.h"
#include <iostream>
#include "hash.h"

int hashFunction(std::string word, int sizeOfHashTable)
{
	int result = 0;
	for (int i = 0; word[i] != '\0'; ++i)
	{
		result += word[i];
	}
	return result % sizeOfHashTable;
}

void createHashTable(List* array[], int sizeOfHashTable)
{
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		array[i] = createList();
	}
}

void printHashTable(List* array[], int sizeOfHashTable)
{
	std::cout << "Hash table:" << std::endl << std::endl;
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		std::cout << "List number " << i << ":" << std::endl;
		printList(array[i]);
		std::cout << std::endl;
	}
}

void deleteHashTable(List* array[], int sizeOfHashTable)
{
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		deleteList(array[i]);
		delete array[i];
	}
}
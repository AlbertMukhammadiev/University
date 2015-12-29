#include "stdafx.h"
#include <iostream>
#include "hash.h"

int hashFunction(const std::string word, int sizeOfHashTable)
{
	int result = 0;
	for (int i = 0; word[i] != '\0'; ++i)
	{
		result += word[i];
	}
	return result % sizeOfHashTable;
}

List **createHashTable(int sizeOfHashTable)
{
	List **hashTable = new List*[sizeOfHashTable] { nullptr };
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
	hashTable[i] = createList();
	}
	return hashTable;
}

void addElementToTable(const std::string word, List **hashTable, int sizeOfHashTabdle)
{
	int i = hashFunction(word, sizeOfHashTabdle);
	addNewElement(word, hashTable[i]);
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
	}
	delete array;
}
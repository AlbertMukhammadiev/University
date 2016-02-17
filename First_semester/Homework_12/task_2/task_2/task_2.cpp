// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <fstream>
#include <ctime>
#include "graph.h"
#include "list.h"

using namespace std;

int main()
{
	int size = 0;
	int buffer = 0;
	ifstream fin("adjacencyMatrix.txt");
	if (!fin.is_open())
	{
		cout << "File can't be opened" << endl;
		return EXIT_FAILURE;
	}
	fin >> size;
	Graph *graph = createGraph(size);
	for (int i = 0; (i < size) && (!fin.eof()); ++i)
	{
		for (int j = 0; (j < size) && (!fin.eof()); ++j)
		{
			fin >> buffer;
			setWeight(graph, i, j, buffer);
		}
	}
	fin.close();

	List *listOfRoads = createList();

	for (int i = 0; i < size; ++i)
	{
		for (int j = i + 1; j < size; ++j)
		{
			if (hasEdge(graph, i, j))
			{
				Road road;
				road.from = i;
				road.to = j;
				road.weight = getWeight(graph, i, j);
				addNewElement(road, listOfRoads);
			}
		}
	}

	Graph *minSpanningTree = createMinSpanningTree(listOfRoads, size);
	printGraph(minSpanningTree, size);
	deleteGraph(graph, size);
	deleteGraph(minSpanningTree, size);
	deleteList(listOfRoads);
	return EXIT_SUCCESS;
}
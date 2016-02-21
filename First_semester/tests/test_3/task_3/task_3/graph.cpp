#include "stdafx.h"
#include <iostream>
#include <fstream>
#include "graph.h"

int **createGraph(int size)
{
	int **matrix = new int*[size] { nullptr };
	for (int i = 0; i < size; ++i)
	{
		matrix[i] = new int[size];
	}
	return matrix;
}

void printGraph(int **matrix, int size)
{
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			std::cout << matrix[i][j] << " ";
		}
		std::cout << std::endl;
	}
}

void fillGraph(int **matrix, int size)
{
	std::ifstream fin("input.txt");
	if (!fin.is_open())
		std::cout << "File can't be opened" << std::endl;
	else
	{
		fin.get();
		int buffer = 0;
		for (int i = 0; i < size; ++i)
		{
			for (int j = 0; j < size; ++j)
			{
				fin >> buffer;
				matrix[i][j] = buffer;
			}
		}
	}
	fin.close();
}

void deleteGraph(int **matrix, int size)
{
	for (int i = 0; i < size; ++i)
	{
		delete[] matrix[i];
	}
	delete[] matrix;
}

void printVertices(int **graph, int size)
{
	List *list = createList();
	bool *visited = new bool[size] { false };
	addNewElement(0, list);
	while (!isEmpty(list))
	{
		int vertex = getValue(list);
		pop(list);
		if (!visited[vertex])
		{
			visited[vertex] = true;
			std::cout << vertex << " ";
			for (int i = 0; i < size; ++i)
			{
				if (graph[vertex][i] > 0)
				{
					addNewElement(i, list);
				}
			}
		}
	}
	delete[] visited;
	deleteList(list);
}
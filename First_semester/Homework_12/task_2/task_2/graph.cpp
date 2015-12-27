#include "stdafx.h"
#include <iostream>
#include "graph.h"

struct Graph
{
	int **array = nullptr;
	int vertexNumber = 0;
};

Graph* createGraph(int size)
{
	Graph *graph = new Graph;
	graph->array = new int*[size];
	for (int i = 0; i < size; ++i)
	{
		graph->array[i] = new int[size];
	}
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			graph->array[i][j] = 0;
		}
	}
	graph->vertexNumber = size;
	return graph;
}

void setWeight(Graph* graph, int vertex1, int vertex2, int weight)
{
	graph->array[vertex1][vertex2] = weight;
	graph->array[vertex2][vertex1] = weight;
}

int getWeight(Graph* graph, int vertex1, int vertex2)
{
	return graph->array[vertex1][vertex2];
}

bool hasEdge(Graph* graph, int vertex1, int vertex2)
{
	return graph->array[vertex1][vertex2] != 0;
}

void printGraph(Graph *graph, int size)
{
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			std::cout << graph->array[i][j] << " ";
		}
		std::cout << std::endl;
	}
}

void deleteGraph(Graph* graph, int size)
{
	for (int i = 0; i < size; ++i)
	{
		delete graph->array[i];
	}
	delete graph->array;
	delete graph;
}

Graph* createMinSpanningTree(List *list, int size)
{
	int *id = new int[size] { 0 };
	for (int i = 0; i < size; ++i)
	{
		id[i] = i;
	}

	Graph* graph = createGraph(size);

	while (!isEmpty(list))
	{
		Road road = getValue(list);
		pop(list);
		int from = road.from;
		int to = road.to;
		int weight = road.weight;
		if (id[from] != id[to])
		{
			for (int i = 0; i < size; ++i)
			{
				if (id[i] == id[to])
				{
					id[i] = id[from];
				}
			}
			setWeight(graph, from, to, weight);
		}
	}
	delete id;
	return graph;
}
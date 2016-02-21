#pragma once
#include "list.h"

struct Graph;

///creates graph and returns the pointer to this graph
Graph* createGraph(int size);

///sets the weight of the edge between vertices 1 and 2
void setWeight(Graph* graph, int vertex1, int vertex2, int weight);

///returns the edge weight between vertices 1 and 2
int getWeight(Graph* graph, int vertex1, int vertex2);

///checks for the existence of the edge between nodes 1 and 2
bool hasEdge(Graph* graph, int vertex1, int vertex2);

void printGraph(Graph *graph, int size);

void deleteGraph(Graph* graph, int size);

///creates minimum spanning tree and returns pointer to graph
Graph* createMinSpanningTree(List *list, int size);
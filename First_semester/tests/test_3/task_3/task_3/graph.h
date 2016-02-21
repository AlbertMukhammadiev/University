#pragma once
#include "list.h"

/// creates graph and returns pointer to it
int **createGraph(int size);

/// prints the elements of the graph in the console
void printGraph(int **graph, int size);

/// reads from file "input.txt" the elements of the graph and fills the graph
void fillGraph(int **graph, int size);

/// frees all memory allocated for the graph
void deleteGraph(int **graph, int size);

/// traverses a graph in breadth and prints its elements
void printVertices(int **graph, int size);
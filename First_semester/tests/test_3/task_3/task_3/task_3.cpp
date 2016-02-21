// task_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <fstream>
#include <iostream>
#include <cstdlib>
#include "graph.h"

using namespace std;

int main()
{
	ifstream fin("input.txt");
	int buffer = 0;
	if (!fin.is_open())
		std::cout << "File can't be opened" << std::endl;
	else
	{
		while (!fin.eof())
		{
			fin >> buffer;
			break;
		}
	}
	fin.close();
	
	int **graph = createGraph(buffer);
	fillGraph(graph, buffer);
	cout << "the adjacency matrix:" << endl;
	printGraph(graph, buffer);
	cout << endl << "vertices:" << endl;
	printVertices(graph, buffer);
	deleteGraph(graph, buffer);
	return EXIT_SUCCESS;
}
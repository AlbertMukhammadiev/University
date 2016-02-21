#include "stdafx.h"
#include <iostream>
#include <ctime>
#include "matrix.h"

int **createMatrix(int height, int width)
{
	int **matrix = new int*[height] { nullptr };
	for (int i = 0; i < height; ++i)
	{
		matrix[i] = new int[width];
	}
	return matrix;
}

void printMatrix(int **matrix, int height, int width)
{
	for (int i = 0; i < height; ++i)
	{
		for (int j = 0; j < width; ++j)
		{
			std::cout << matrix[i][j] << " ";
		}
		std::cout << std::endl;
	}
}

void fillMatrix(int **matrix, int height, int width)
{
	srand(time(0));
	for (int i = 0; i < height; ++i)
	{
		for (int j = 0; j < width; ++j)
		{
			matrix[i][j] = rand() % 10;
		}
	}
}

void deleteMatrix(int **matrix, int height, int width)
{
	for (int i = 0; i < height; ++i)
	{
		delete[] matrix[i];
	}
	delete[] matrix;
}
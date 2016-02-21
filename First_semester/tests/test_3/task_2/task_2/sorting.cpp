#include "stdafx.h"
#include "sorting.h"

void bubbleSort(int **matrix, int height, int width)
{
	for (int i = 0; i < width - 1; ++i)
	{
		for (int j = 0; j < width - i - 1; ++j)
			if (matrix[0][j + 1] < matrix[0][j])
			{
				for (int k = 0; k < height; ++k)
				{
					int temp = matrix[k][j];
					matrix[k][j] = matrix[k][j + 1];
					matrix[k][j + 1] = temp;
				}
			}
	}
}
// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include "matrix.h"
#include "sorting.h"

using namespace std;

int main()
{
	cout << "enter the height and width of matrix:" << endl;
	int n = 0;
	cin >> n;
	int m = 0;
	cin >> m;
	int **matrix = createMatrix(n, m);
	fillMatrix(matrix, n, m);
	cout << "the original matrix" << endl;
	printMatrix(matrix, n, m);
	bubbleSort(matrix, n, m);
	cout << endl;
	cout << "sorted matrix" << endl;
	printMatrix(matrix, n, m);
	deleteMatrix(matrix, n, m);
    return EXIT_SUCCESS;
}


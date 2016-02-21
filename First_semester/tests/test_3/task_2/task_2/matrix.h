#pragma once

/// creates matrix and returns pointer to it
int **createMatrix(int height, int width);

/// prints the elements of the matrix to console
void printMatrix(int **matrix, int height, int width);

/// fills the matrix with random numbers not more than 10
void fillMatrix(int **matrix, int height, int width);

/// frees all memory allocated for the matrix
void deleteMatrix(int **matrix, int height, int width);
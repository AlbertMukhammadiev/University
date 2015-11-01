// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>

using namespace std;

int main()
{
	int x = 0;
	cout << "Write number, please" << endl;
	cin >> x;
	int sqrX = x * x;
	cout << (sqrX + x) * (sqrX + 1) + 1 << endl;
	return EXIT_SUCCESS;
}
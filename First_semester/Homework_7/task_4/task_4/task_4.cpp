// task_4.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include "stack.h"
#include "converting.h"

using namespace std;

int main()
{
	cout << "enter the expression in infix form" << endl;
	char string[1000] = {};
	char buffer = getchar();
	int length = 0;
	for (int i = 0; (buffer != EOF) && (buffer != '\n'); ++i)
	{
		string[i] = buffer;
		buffer = getchar();
		++length;
	}
	Stack *stack = createStack();
	convertToPostfixForm(string, stack, length);
	deleteStack(stack);
	return EXIT_SUCCESS;
}
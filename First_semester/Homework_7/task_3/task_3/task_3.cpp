// task_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include "stack.h"
#include "checking.h"

using namespace std;

int main()
{
	cout << "Enter the string, please" << endl;
	char string[1000] = {};
	char buffer = getchar();
	for (int i = 0; (buffer != EOF) && (buffer != '\n'); ++i)
	{
		string[i] = buffer;
		buffer = getchar();
	}

	Stack *stack = createStack();
	if (ruleOfNesting(string, stack))
	{
		cout << "OK" << endl;;
	}
	else
	{
		cout << "A rule of nesting of parentheses is violated" << endl;
	}
	deleteStack(stack);
	delete stack;
	return EXIT_SUCCESS;
}
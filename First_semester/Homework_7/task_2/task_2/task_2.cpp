// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include "stack.h"
#include "calculator.h"

using namespace std;

int main()
{
	Stack *stack = createStack();
	cout << "Enter an expression in Postfix form(after the expression, type sign =):" << endl;
	char symbol = ' ';
	int result = 0;
	while (symbol != '=')
	{
		cin >> symbol;
		if ((symbol == '+') || (symbol == '-') || (symbol == '/') || (symbol == '*'))
		{
			result = calculator(symbol, stack);
			push(result, stack);
		}
		else
		{
			push(symbol, stack);
		}
	}
	cout << "result = " << result - '0' << endl;
	deleteStack(stack);
	delete stack;
	return EXIT_SUCCESS;
}
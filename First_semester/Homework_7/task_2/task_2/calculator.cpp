#include "stdafx.h"
#include <iostream>
#include "calculator.h"
#include "stack.h"

int calculator(char operation, Stack *stack, bool &correctnessOfEntry)
{
	if (isEmpty(stack))
	{
		std::cout << "Postfix notation is incorrect" << std::endl;
		correctnessOfEntry = false;
		return 0;
	}
	Value operand1 = getValue(stack);
	pop(stack);
	if (isEmpty(stack))
	{
		std::cout << "Postfix notation is incorrect" << std::endl;
		correctnessOfEntry = false;
		return 0;
	}
	Value operand2 = getValue(stack);
	pop(stack);
	switch (operation)
	{
	case '+':
	{
		return operand2 + operand1;
	}
	case '-':
	{
		return operand2 - operand1;
	}
	case '/':
	{
		return operand2 / operand1;
	}
	case '*':
	{
		return operand2 * operand1;
	}
	default:
		break;
	}
}
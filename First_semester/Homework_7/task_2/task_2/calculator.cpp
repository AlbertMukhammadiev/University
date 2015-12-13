#include "stdafx.h"
#include "calculator.h"
#include "stack.h"

int calculator(Value oper, Stack *stack)
{
	Value operand1 = getValue(stack);
	pop(stack);
	Value operand2 = getValue(stack);
	pop(stack);
	switch (oper)
	{
	case '+':
	{
		return operand2 + operand1 - '0';
	}
	case '-':
	{
		return operand2 - operand1 + '0';
	}
	case '/':
	{
		return (operand2 - '0') / (operand1 - '0') + '0';
	}
	case '*':
	{
		return (operand2 - '0') * (operand1 - '0') + '0';
	}
	}
}
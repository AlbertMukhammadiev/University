#include "stdafx.h"
#include <iostream>
#include "converting.h"

int priority(char operation)
{
	switch (operation)
	{
	case '+':
	case '-':
	{
		return 1;
	}
	case '*':
	case '/':
	{
		return 2;
	}
	case '(':
	{
		return 0;
	}
	default:
		break;
	}
}

void convertToPostfixForm(char string[], Stack *stack, int length)
{
	for (int i = 0; i < length; ++i)
	{
		if (('0' <= string[i]) && (string[i] <= '9'))
		{
			std::cout << string[i] << " ";
		}
		else
		{
			switch (string[i])
			{
			case '+':
			case '-':
			case '*':
			case '/':
			{
				if (empty(stack))
				{
					push(string[i], stack);
				}
				else if (priority(string[i]) == 1)
				{
					while (((!empty(stack))
						&& ((priority(getValue(stack)) == 2)
						|| (priority(string[i])) <= (priority(getValue(stack))))))
					{
						std::cout << getValue(stack) << " ";
						pop(stack);
					}
					push(string[i], stack);
				}
				else if (priority(string[i]) > priority(getValue(stack)))
				{
					push(string[i], stack);
				}

				break;
			}
			case '(':
			{
				push(string[i], stack);
				break;
			}
			case ')':
			{
				while (getValue(stack) != '(')
				{
					std::cout << getValue(stack) << " ";
					pop(stack);
				}
				pop(stack);
				break;
			}
			default:
				break;
			}
		}
	}
	if (!empty(stack))
	{
		printStack(stack);
	}
}
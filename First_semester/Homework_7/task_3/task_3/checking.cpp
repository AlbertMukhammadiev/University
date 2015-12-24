#include "stdafx.h"
#include "checking.h"

bool ruleOfNesting(char string[], Stack *stack)
{
	for (int i = 0; string[i] != '\0'; ++i)
	{
		if ((string[i] == ')') || (string[i] == '}') || (string[i] == ']'))
		{
			if (isEmpty(stack))
				return false;

			switch (string[i])
			{
			case ')':
			{
				if (getValue(stack) != '(')
				{
					return false;
				}
				pop(stack);
				break;
			}
			case ']':
			{
				if (getValue(stack) != '[')
				{
					return false;
				}
				pop(stack);
				break;
			}
			case '}':
			{
				if (getValue(stack) != '{')
				{
					return false;
				}
				pop(stack);
				break;
			}
			default:
				break;
			}
		}
		else if ((string[i] == '(') || (string[i] == '{') || (string[i] == '['))
		{
			push(string[i], stack);
		}
	}
	return isEmpty(stack);
}
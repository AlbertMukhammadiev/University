// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>

using namespace std;

enum State
{
	Start,
	FirstDigit,
	Digits,
	Dot,
	DigitsAfterDot,
	Base,
	Sign,
	Degree,
	Error,
	End
};

bool isDigit(char symbol)
{
	return ((symbol <= '9') && (symbol >= '0'));
}

bool isDot(char symbol)
{
	return (symbol == '.');
}

bool isBase(char symbol)
{
	return (symbol == 'E');
}

bool isSign(char symbol)
{
	return (symbol == '+') || (symbol == '-');
}

bool isEnd(char symbol)
{
	return (symbol == '\0') || (symbol == '\n');
}

int main()
{
	cout << "Enter the string, please" << endl
		<< "checking of correctness of the entry of a real number" << endl;
	char symbol = getchar();
	State currentState = Start;
	while ((currentState != Error) && (currentState != End))
	{
		switch (currentState)
		{
		case Start:
		{
			currentState = isDigit(symbol) ? FirstDigit : Error;
			break;
		}
		case FirstDigit:
		{
			if (isDigit(symbol))
			{
				currentState = Digits;
			}
			else if (isEnd(symbol))
			{
				currentState = End;
			}
			else if (isDot(symbol))
			{
				currentState = Dot;
			}
			else if (isBase(symbol))
			{
				currentState = Base;
			}
			else
			{
				currentState = Error;
			}
			break;
		}
		case Digits:
		{
			if (isDigit(symbol))
			{
				currentState = Digits;
			}
			else if (isEnd(symbol))
			{
				currentState = End;
			}
			else if (isDot(symbol))
			{
				currentState = Dot;
			}
			else if (isBase(symbol))
			{
				currentState = Base;
			}
			else
			{
				currentState = Error;
			}
			break;
		}
		case Dot:
		{
			if (isDigit(symbol))
			{
				currentState = DigitsAfterDot;
				break;
			}
			currentState = isEnd(symbol) ? End : Error;
			break;
		}
		case DigitsAfterDot:
		{
			if (isDigit(symbol))
			{
				currentState = DigitsAfterDot;
			}
			else if (isEnd(symbol))
			{
				currentState = End;
			}
			else if (isBase(symbol))
			{
				currentState = Base;
			}
			else
			{
				currentState = Error;
			}
			break;
		}
		case Base:
		{
			if (isSign(symbol))
			{
				currentState = Sign;
			}
			else if (isDigit(symbol))
			{
				currentState = Degree;
			}
			else
			{
				currentState = Error;
			}
			break;
		}
		case Sign:
		{
			currentState = isDigit(symbol) ? Degree : Error;
			break;
		}
		case Degree:
		{
			if (isDigit(symbol))
			{
				currentState = Degree;
				break;
			}
			currentState = isEnd(symbol) ? End : Error;
			break;
		}
		default:
			break;
		}
		
		if (currentState != End)
		{
			symbol = getchar();
		}
	}
	currentState == End ? cout << "Ok" : cout << "Error";
	cout << endl;
	return EXIT_SUCCESS;
}


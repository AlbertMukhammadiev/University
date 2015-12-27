// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>

using namespace std;

enum State
{
	Text,
	Slash,
	Star,
	Comment,
	CommentStar,
	End
};

bool isStar(char symbol)
{
	return (symbol == '*');
}

bool isSlash(char symbol)
{
	return (symbol == '/');
}

bool isEnd(char symbol)
{
	return (symbol == '\n');
}

int main()
{
	ifstream fin("Text.txt");
	if (!fin.is_open())
		cout << "File can't be opened!" << endl;
	else
	{
		cout << "Comments:" << endl;
		State currentState = Text;
		string buffer = "";
		char symbol = fin.get();
		while (!fin.eof())
		{
			switch (currentState)
			{
			case Text:
			{
				if (isSlash(symbol))
				{
					currentState = Slash;
				}
				else if (isEnd(symbol))
				{
					currentState = End;
				}
				else
				{
					currentState = Text;
				}
				break;
			}
			case Slash:
			{
				if (isStar(symbol))
				{
					currentState = Comment;
				}
				else if (isSlash(symbol))
				{
					currentState = Slash;
				}
				else if (isEnd(symbol))
				{
					currentState = End;
				}
				else
				{
					currentState = Text;
				}
				break;
			}
			case Star:
			{
				if (isStar(symbol))
				{
					currentState = Star;
				}
				else if (isEnd(symbol))
				{
					currentState = End;
				}
				else
				{
					currentState = Text;
				}
				break;
			}
			case Comment:
			{
				buffer += symbol;
				if (isStar(symbol))
				{
					currentState = CommentStar;
				}
				else if (isEnd(symbol))
				{
					buffer = "";
					currentState = End;
				}
				else
				{
					currentState = Comment;
				}
				break;
			}
			case CommentStar:
			{
				if (isSlash(symbol))
				{
					cout << "/*" << buffer << "/" << endl;
					buffer = "";
					currentState = Text;
				}
				else if (isEnd(symbol))
				{
					buffer = "";
					currentState = End;
				}
				else if (isStar(symbol))
				{
					buffer += symbol;
					currentState = CommentStar;
				}
				else
				{
					buffer += symbol;
					currentState = Comment;
				}
				break;
			}
			default:
				break;
			}
			symbol = fin.get();
		}
	}
	fin.close();
    return EXIT_SUCCESS;
}


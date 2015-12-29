// task_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>

using namespace std;

int index(char symbol)
{
	if (symbol == '*')
	{
		return 0;
	}
	else if (symbol == '/')
	{
		return 1;
	}
	else
	{
		return 2;
	}
}

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
	State matrix[6][3] = { 
		{Text, Slash, Text}, 
		{Comment, Slash, Text}, 
		{Star, Slash, Text},
		{CommentStar, Comment, Comment}, 
		{CommentStar, Text, Comment}, 
		{End, End, End} 
	};

	ifstream fin("Text.txt");
	if (!fin.is_open())
		cout << "File can't be opened!" << endl;
	else
	{
		cout << "Comments:" << endl;
		State currentState = Text;
		string buffer = "";
		char symbol = '/0';
		while (!fin.eof())
		{
			char symbol = fin.get();
			State previousState = currentState;
			
			currentState = matrix[previousState][index(symbol)];

			if (currentState == Comment)
			{
				buffer += symbol;
			}

			if ((currentState == Text) && (previousState == CommentStar))
			{
				cout << "/" << buffer << "*/" << endl;
				buffer = "";
			}
		}
	}
	fin.close();
    return EXIT_SUCCESS;
}


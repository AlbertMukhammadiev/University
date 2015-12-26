// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <locale.h>

using namespace std;

void convertToBinary(bool array[], int number, int sizeOfInteger)
{
	for (int i = 0; i < sizeOfInteger; ++i)
	{	
		if ((number & 1) == 1)
		{
			array[i] = true;
		}
		number = number >> 1;
	}
}

int convertToDecimal(bool array[], int sizeOfInteger)
{
	int degTwo = 1;
	int number = 0;
	for (int i = 0; i < sizeOfInteger; ++i)
	{
		if (array[i])
		{
			number += degTwo;
		}
		degTwo = degTwo * 2;
	}
	return number;
}

void sumUp(bool number1[], bool number2[], bool sum[], int sizeOfInteger)
{
	bool mental = false;
	int forMental = 0;
	for (int i = 0; i < sizeOfInteger; ++i)
	{
		sum[i] = number1[i] ^ number2[i] ^ mental;
		forMental = number1[i] + number2[i] + mental;
		mental = (forMental >= 2)
	}
}

void printBinaryForm(bool array[], int sizeOfInteger)
{
	for (int i = sizeOfInteger - 1; i > 0; --i)
	{
		cout << array[i] << " ";
	}
	cout << array[0] << endl;
}

int main()
{
	setlocale(0, "");
	cout << "Введите два числа, пожалуйста:" << endl;
	int number1 = 0;
	int number2 = 0;
	cin >> number1 >> number2;
	const int sizeOfInteger = 32;
	bool bitMask1[sizeOfInteger] = {};
	bool bitMask2[sizeOfInteger] = {};
	convertToBinary(bitMask1, number1, sizeOfInteger);
	cout << endl << "Первое число в двоичной системе счисления:" << endl;
	printBinaryForm(bitMask1, sizeOfInteger);
	convertToBinary(bitMask2, number2, sizeOfInteger);
	cout << endl << "Второе число в двоичной системе счисления:" << endl;
	printBinaryForm(bitMask2, sizeOfInteger);
	bool sum[sizeOfInteger] = {};
	sumUp(bitMask1, bitMask2, sum, sizeOfInteger);
	cout << endl << "Сумма в двоичной системе счисления:" << endl;
	printBinaryForm(sum, sizeOfInteger);
	cout << endl << "Сумма после перевода из двоичной в десятичную систему счисления:";
	cout << endl << convertToDecimal(sum, sizeOfInteger) << endl;
	return EXIT_SUCCESS;
}

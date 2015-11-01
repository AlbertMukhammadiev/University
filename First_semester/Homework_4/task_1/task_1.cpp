// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include <locale.h>

using namespace std;

void convertToBinary(bool array[], int number)
{
	for (int i = 0; i < 32; ++i)
	{	
		if ((number & 1) == 1)
		{
			array[i] = true;
		}
		number = number >> 1;
	}
}

int convertToDecimal(bool array[])
{
	int degTwo = 1;
	int number = 0;
	for (int i = 0; i <= 31; ++i)
	{
		if (array[i])
		{
			number += degTwo;
		}
		degTwo = degTwo * 2;
	}
	return number;
}

void sumUp(bool number1[], bool number2[], bool sum[])
{
	bool mental = false;
	int forMental = 0;
	for (int i = 0; i <=31; ++i)
	{
		sum[i] = number1[i] ^ number2[i] ^ mental;
		forMental = number1[i] + number2[i] + mental;
		if (forMental >= 2)
		{
			mental = true;
		}
		else
		{
			mental = false;
		}
	}
}

void printBinaryForm(bool array[])
{
	for (int i = 31; i > 0; --i)
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
	bool bitMask1[32] = {};
	bool bitMask2[32] = {};
	convertToBinary(bitMask1, number1);
	cout << endl << "Первое число в двоичной системе счисления:" << endl;
	printBinaryForm(bitMask1);
	convertToBinary(bitMask2, number2);
	cout << endl << "Второе число в двоичной системе счисления:" << endl;
	printBinaryForm(bitMask2);
	bool sum[32] = {};
	sumUp(bitMask1, bitMask2, sum);
	cout << endl << "Сумма в двоичной системе счисления:" << endl;
	printBinaryForm(sum);
	cout << endl << "Сумма после перевода из двоичной в десятичную систему счисления:";
	cout << endl << convertToDecimal(sum) << endl;
	return EXIT_SUCCESS;
}

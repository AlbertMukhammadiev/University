// task_1.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include "list.h"
#include "city.h"

using namespace std;

int main()
{
	/*cout << "enter the number n(the number of cities):";
	int n = 0;
	cin >> n;
	cout << "enter the number m(the number of roads):";
	int m = 0;
	cin >> m;*/
	//int **arrayOfRoads = new int*[n];
	/*for (int i = 0; i < m; ++i)
	{
		arrayOfRoads[i] = new int[n];
	}*/
	cout << "enter the road in the format: i j len" << endl
		<< "i and j - the sequence number of the city; len - the length of the road" << endl;
	const int m = 8;
	const int n = 6;
	int arrayOfRoads[n][n] = { 0 };
	
	///fills the adjacency matrix
	for (int l = 0; l < m; ++l)
	{
		int i = 0;
		cin >> i;
		int j = 0;
		cin >> j;
		int length = 0;
		cin >> length;
		arrayOfRoads[i][j] = length;
		arrayOfRoads[j][i] = length;
	}

	cout << "enter the number k(number of capitals): ";
	//int k = 0;
	//cin >> k;
	const int k = 2;
	cout << endl << "enter the serial numbers of the capitals:" << endl;
	List *states[k] = { nullptr };
	List *neighborsOfStates[k] = { nullptr };
	bool cities[n] = { true };
	for (int i = 0; i < k; ++i)
	{
		int number = 0;
		cin >> number;
		states[i] = createList();
		neighborsOfStates[i] = createList();
		
		City city;
		city.sequenceNumber = number;
		addNewElement(city, neighborsOfStates[i]);
		cities[number] = false;
	}
	int numOfUnoccupiedCities = n;
	int numOfUnvisitedCities = n - k;
	
	while (numOfUnvisitedCities > 0)
	{
		for (int i = 0; (i < k); ++i)
		{
			City city = getValue(neighborsOfStates[i]);
			pop(neighborsOfStates[i]);
			if (cities[city.sequenceNumber])
			{
				addNewElement(city, states[i]);
				--numOfUnoccupiedCities;
				cities[city.sequenceNumber] = false;
			}
			for (int j = 1; j <= n; ++j)
			{
				if (arrayOfRoads[city.sequenceNumber][j] > 0)
				{
					city.sequenceNumber = j;
					city.wayToCity = arrayOfRoads[city.sequenceNumber][j];
					addNewElement(city, neighborsOfStates[i]);
					--numOfUnvisitedCities;
				}
			}
		}
	}
	
	int i = 0;
	while (numOfUnoccupiedCities > 0)
	{
		if (!isEmpty(neighborsOfStates[i]))
		{
			City city = getValue(neighborsOfStates[i]);
			pop(neighborsOfStates[i]);
			if (cities[city.sequenceNumber])
			{
				addNewElement(city, states[i]);
				--numOfUnoccupiedCities;
				cities[city.sequenceNumber] = false;
			}
		}
		i = (i + 1) % k;
	}
	for (int i = 0; i < k; ++i)
	{
		printList(states[i]);
		cout << endl;
	}
	return EXIT_SUCCESS;
}


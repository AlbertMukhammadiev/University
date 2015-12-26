// task_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <cstdlib>
#include <iostream>
#include "list.h"
#include "city.h"

using namespace std;

int main()
{
	cout << "enter the number n(the number of cities):";
	int n = 0;
	cin >> n;
	cout << "enter the number m(the number of roads):";
	int m = 0;
	cin >> m;
	int **arrayOfRoads = new int*[n];
	for (int i = 0; i < n; ++i)
	{
		arrayOfRoads[i] = new int[n];
	}
	cout << "enter the road in the format: i j len" << endl
		<< "i and j - the sequence number of the city; len - the length of the road" << endl;
	
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
	int k = 0;
	cin >> k;
	cout << endl << "enter the serial numbers of the capitals:" << endl;
	List **states = createArrayOfLists(k);
	List **neighborsOfStates = createArrayOfLists(k);
	bool *cities = new bool[n] {};
	for (int i = 0; i < k; ++i)
	{
		int number = 0;
		cin >> number;
		states[i] = createList();
		neighborsOfStates[i] = createList();
		
		City city;
		city.sequenceNumber = number;
		addNewElement(city, neighborsOfStates[i]);
	}
	int numOfUnoccupiedCities = n;
	int numOfUnvisitedCities = n - k;
	
	while (numOfUnvisitedCities > 0)
	{
		for (int l = 0; (l < k); ++l)
		{
			City city = getValue(neighborsOfStates[l]);
			while (cities[city.sequenceNumber])
			{
				pop(neighborsOfStates[l]);
				city = getValue(neighborsOfStates[l]);
			}
			
			if (!cities[city.sequenceNumber])
			{
				addNewElement(city, states[l]);
				--numOfUnoccupiedCities;
				cities[city.sequenceNumber] = true;
				
				int i = city.sequenceNumber;
				int j = 0;
				while (j < n)
				{
					if ((arrayOfRoads[i][j] > 0) && (!cities[j]))
					{
						city.wayToCity = arrayOfRoads[i][j];
						city.sequenceNumber = j;
						addNewElement(city, neighborsOfStates[l]);
						--numOfUnvisitedCities;
					}
					++j;
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
			while (cities[city.sequenceNumber])
			{
				pop(neighborsOfStates[i]);
				city = getValue(neighborsOfStates[i]);
			}

			if (!cities[city.sequenceNumber])
			{
				addNewElement(city, states[i]);
				--numOfUnoccupiedCities;
				cities[city.sequenceNumber] = true;
			}
		}
		i = (i + 1) % k;
	}
	for (int i = 0; i < k; ++i)
	{
		cout << "State number " << i << ":" << endl;
		printList(states[i]);
		cout << endl;
	}

	delete cities;

	
	for (int i = 0; i < n; ++i)
	{
		delete arrayOfRoads[i];
	}
	delete *arrayOfRoads;

	deleteArrayOfLists(states, n);
	deleteArrayOfLists(neighborsOfStates, n);
	return EXIT_SUCCESS;
}


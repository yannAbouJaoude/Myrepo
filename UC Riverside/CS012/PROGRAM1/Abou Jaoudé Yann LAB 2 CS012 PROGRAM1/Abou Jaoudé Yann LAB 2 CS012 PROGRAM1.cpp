// Abou Jaoudé Yann LAB 2 CS012 PROGRAM1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <cstdlib>
//#include <cmath>
//#include <ctime>
#include <vector>
#include <string>
#include <fstream>
#include <windows.h>
#include <conio.h>

using namespace std;
bool readWindTunnelData(const string inputFile, vector <double> &flightPath, vector <double> &coefficientOfLift);
double LinearInterpolation(const vector <double> &flightPath, const vector <double> &coefficientOfLift, double newFlightPathValue);
bool isOrdered(const vector <double> &flightPath);
void reorder(vector <double> &flightPath, vector <double> &coefficientOfLift);
bool isVectorCorrect(vector <double> &flightPath, vector <double> &coefficientOfLift);
double minValue(const vector <double> &flightPath);
double maxValue(const vector <double> &flightPath);

int main() {
	bool resterDansLeMenu = true;
	int choix;
	int positionMenu = 0;
	int col = 47;
	HANDLE H = GetStdHandle(STD_OUTPUT_HANDLE);
	/* variables*/

	string inputFile;
	vector <double> flightPath;
	vector <double> coefficientOfLift;
	bool found;
	double newFlightPathValue;
	/* Names of exercices*/

	string exerciceList[] = { "Read Data","Linear Interpolation","Is Ordered","Reorder","Quit" };
	int numberOfExercice = 5;//sizeof(exerciceList) ->error
	
	//int numberOfExercice = sizeof(exerciceList);
	//	cout << sizeof(exerciceList) << endl;

	for (int i = 0; i < numberOfExercice; i++)
	{
		if (i == positionMenu)
		{
			SetConsoleTextAttribute(H, col);
		}
		else
		{
			SetConsoleTextAttribute(H, 15);
		}
		cout << exerciceList[i] << endl;
		SetConsoleTextAttribute(H, 15);
	}

	while (resterDansLeMenu)
	{


		choix = _getch();

		system("cls");

		if (choix == 72 && positionMenu > 0) { positionMenu--; }
		if (choix == 80 && positionMenu < numberOfExercice - 1) { positionMenu++; }
		if (choix == 13)
		{
			switch (positionMenu) // main of exercices
			{
			case 0:
				found = false;
				while (!found) {
					cout << "Enter name of input file: " << endl;
					cin >> inputFile;
					cout << endl;
					
					found = readWindTunnelData(inputFile, flightPath, coefficientOfLift);
				}
				break;
			case 1:
				if (isVectorCorrect(flightPath, coefficientOfLift)){
					if (!isOrdered(flightPath)) {
						cout << "The vector isnt ordered, lets make some order" << endl;
						reorder(flightPath, coefficientOfLift);
					}
					cout << "Enter a flight path value " << endl;
					cin >> newFlightPathValue;
					double result = LinearInterpolation(flightPath, coefficientOfLift, newFlightPathValue);
					if (result!=minValue(flightPath)-1) {
						cout << "By Linear interpolation, the value of the flight path " << newFlightPathValue << " is " << result << endl;
					}
					else {
						cout << "This program isnt designed to extrapolate, but only to interpolate" << endl;
						cout << "Please retry with a value between " << minValue(flightPath) << " and " << maxValue(flightPath) << endl;
					}
			    }
				else { cout << "please Load a correct file" << endl; }
				break;
			case 2:
				if (isVectorCorrect(flightPath, coefficientOfLift)) {
				if (isOrdered(flightPath)) {
					cout << "The vector is ordered" << endl;
				}
				else {
					cout << "The vector isnt ordered" << endl;
				}
				}
				else { cout << "please Load a correct file" << endl; }
				break;
			case 3:
				if (isVectorCorrect(flightPath, coefficientOfLift)) {
					reorder(flightPath, coefficientOfLift);
				}
				else { cout << "please Load a correct file" << endl; }
				break;
			case 4:
				cout << ("Goodbye") << endl;
				system("PAUSE");
				return 0;
				break;
			default:
				cout << ("The exercice isnt done yet.") << endl;
				break;
			}
			system("PAUSE");
			system("cls");
		}
		for (int i = 0; i < numberOfExercice; i++)
		{
			if (i == positionMenu)
			{
				SetConsoleTextAttribute(H, col);
			}
			else
			{
				SetConsoleTextAttribute(H, 15);
			}
			cout << exerciceList[i] << endl;
			SetConsoleTextAttribute(H, 15);
		}
	}
}



bool readWindTunnelData(const string inputFile, vector <double> &flightPath, vector <double> &coefficientOfLift) {
	
	ifstream file(inputFile.c_str(), ios::in);
	if (file)
	{
		string number = "";
		char myChar;
		bool precedentCharIsDigit= false;
		bool flightPathTurn= true;
		int unespectedChar = 0;
		while (file.get(myChar)) {
			cout << myChar;
			if (isdigit(myChar)||myChar=='-'||myChar=='.') {
				number += myChar;
				precedentCharIsDigit = true;
			}
			else if (precedentCharIsDigit) {
				if (flightPathTurn) {
					flightPath.push_back(stod(number));
					precedentCharIsDigit = false;
					flightPathTurn = false;
				}
				else {
					coefficientOfLift.push_back(stod(number));
					precedentCharIsDigit = false;
					flightPathTurn = true;
				}			
				number = "";
				if (myChar != ' ' && myChar != '\n') {
					unespectedChar++;
				}
			}
		}
		if (precedentCharIsDigit) {
			coefficientOfLift.push_back(stod(number));
		}
		cout << endl;
		if (unespectedChar != 0) {
			cout << "There is " << unespectedChar << " unespected characters" << endl;
		}
		file.close();
		return true;
	}
	else
	{
		cerr << "Error.File not found.Please retry" << endl;
		return false;
	}
}
double LinearInterpolation(const vector <double> &flightPath, const vector <double> &coefficientOfLift, double newFlightPathValue) {
	bool found = false;
	for (int i = 0; i < flightPath.size(); i++)
	{
		if (flightPath[i] == newFlightPathValue) {
			found = true;
			return coefficientOfLift[i];
		}
	}	
	double flightDown= flightPath[0];
	double flightUp= flightPath[1];
	int i = 1;
	while (flightUp < flightPath[flightPath.size() - 1]&& flightUp< newFlightPathValue) {
		flightUp = flightPath[i];
		if (flightUp > newFlightPathValue) {
			flightDown = flightPath[i - 1];
			found = true;
		}
		i++;
	}
	if (found) {
		return coefficientOfLift[i - 2] + ((newFlightPathValue - flightDown) / (flightUp - flightDown))*(coefficientOfLift[i-1] - coefficientOfLift[i - 2]);
	}
 	return minValue(flightPath)-1;
	
// a= i-1 c = i
//	f(b) = f(a) + ((b - a) / (c - a))(f(c) - f(a))


}
bool isOrdered(const vector <double> &flightPath) {
	for (int i = 0; i < flightPath.size()-1; i++)
	{
		if (flightPath[i] > flightPath[i + 1]) {
			return false;
		}
	}
	return true;
}
void reorder(vector <double> &flightPath, vector <double> &coefficientOfLift) {
	bool tabInOrder = false;
	int tmp = flightPath.size();
	while (!tabInOrder)
	{
		tabInOrder = true;
		for (int i = 0; i < tmp - 1; i++)
		{
			if (flightPath[i] > flightPath[i + 1])
			{
				swap(flightPath[i], flightPath[i + 1]);
				swap(coefficientOfLift[i], coefficientOfLift[i + 1]);
				tabInOrder = false;
			}
		}
		tmp--;
	}
	cout << "the vector is now ordered" << endl;
}
void swap(double &a, double &b) {
	int tmp = a;
	a = b;
	b = tmp;
}
bool isVectorCorrect(vector <double> &flightPath, vector <double> &coefficientOfLift) {
	if (flightPath.size() == coefficientOfLift.size() && flightPath.size() != 0) {
		return true;
	}
	return false;
}
double minValue(const vector <double> &flightPath) {
	double result = flightPath[0];
	for (int i = 1; i < flightPath.size(); i++)
	{
		if (flightPath[i] < result) {
			result = flightPath[i];
		}
	}
	return result;
}
double maxValue(const vector <double> &flightPath) {
	double result = flightPath[0];
	for (int i = 1; i < flightPath.size(); i++)
	{
		if (flightPath[i] > result) {
			result = flightPath[i];
		}
	}
	return result;
}

// Abou Jaoudé Yann LAB 2 CS012 PROGRAM1.cpp : Defines the entry point for the console application.

#include <iostream>
#include <cstdlib>
#include <vector>

#include <fstream>


using namespace std;
void readData(const string inputFile, vector <double> &flightPath, vector <double> &coefficientOfLift);
double interpolation(double newFlightPathValueconst, vector <double> &flightPath, const vector <double> &coefficientOfLift);
bool isOrdered(const vector <double> &flightPath);
void reorder(vector <double> &flightPath, vector <double> &coefficientOfLift);
double minValue(const vector <double> &flightPath);
double maxValue(const vector <double> &flightPath);


int main(){

}

void readData(const string inputFile, vector <double> &flightPath, vector <double> &coefficientOfLift) {
	
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
			if (myChar=='1'||myChar=='2'||myChar=='3'||myChar=='4'||myChar=='5'||myChar=='6'||myChar=='7'||myChar=='8'||myChar=='9'||myChar=='0'||myChar=='-'||myChar=='.') {
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
	}
	else
	{
		cerr << "Error.File not found.Please retry" << endl;
	}
}
double interpolation(double newFlightPathValue,const vector <double> &flightPath, const vector <double> &coefficientOfLift) {
	bool found = false;
	for (unsigned int i = 0; i < flightPath.size(); i++)
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
	for (unsigned int i = 0; i < flightPath.size()-1; i++)
	{
		if (flightPath[i] > flightPath[i + 1]) {//>
			return false;
		}
	}
	return true;
}
void reorder(vector <double> &flightPath, vector <double> &coefficientOfLift) {
	bool tabInOrder = false;
	size_t tmp = flightPath.size();
	while (!tabInOrder)
	{
		tabInOrder = true;
		for (unsigned int i = 0; i < tmp - 1; i++)
		{
			if (flightPath[i] > flightPath[i + 1])//>
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
	double tmp = a;
	a = b;
	b = tmp;
}

double minValue(const vector <double> &flightPath) {
	double result = flightPath[0];
	for (unsigned int i = 1; i < flightPath.size(); i++)
	{
		if (flightPath[i] < result) {
			result = flightPath[i];
		}
	}
	return result;
}
double maxValue(const vector <double> &flightPath) {
	double result = flightPath[0];
	for (unsigned int i = 1; i < flightPath.size(); i++)
	{
		if (flightPath[i] > result) {
			result = flightPath[i];
		}
	}
	return result;
}

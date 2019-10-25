// Abou Jaoudé Yann LAB 2 CS012 PROGRAM1.cpp : Defines the entry point for the console application.
//

#include <iostream>
#include <vector>
#include <string>
#include <fstream>

using namespace std;
void readData(const string inputFile, vector <double> &flightPath, vector <double> &coefficientOfLift);
double interpolation(double newFlightPathValue,const vector <double> &flightPath, const vector <double> &coefficientOfLift);
bool isOrdered(const vector <double> &flightPath);
void reorder(vector <double> &flightPath, vector <double> &coefficientOfLift);
bool isVectorCorrect(vector <double> &flightPath, vector <double> &coefficientOfLift);
double minValue(const vector <double> &flightPath);
double maxValue(const vector <double> &flightPath);

int main() {
	vector <double> flightPath;
	vector <double> coefficientOfLift;
	string inputFile;
	cout << "Enter name of input data file:"<<endl;
	cin>>inputFile;
	cout<<endl;
	readData(inputFile,flightPath,coefficientOfLift);
}
void readData(const string inputFile, vector <double> &flightPath, vector <double> &coefficientOfLift) {
	
	ifstream file(inputFile.c_str(), ios::in);
	if (file)
	{
		string number = "";
		char myChar;
		bool precedentCharIsDigit= false;
		bool flightPathTurn= true;
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
			}
		}
		if (precedentCharIsDigit) {
			coefficientOfLift.push_back(stod(number));
		}
		file.close();
	}
	else
	{
		cerr << "Error opening "<< inputFile << endl;
		exit(1);
	}
}
double interpolation(double newFlightPathValue, const vector <double> &flightPath, const vector <double> &coefficientOfLift) {
	bool found = false;
	for (unsigned int i = 0; i < flightPath.size(); i++)
	{
		if (flightPath[i] == newFlightPathValue) {
			found = true;
			return coefficientOfLift[i];

		}
	}	
	if(flightPath[0]> newFlightPathValue||flightPath[flightPath.size() - 1]<newFlightPathValue){
		return 0;
	}
	int i = 0;
	while (flightPath[i] < flightPath[flightPath.size() - 1]&& flightPath[i]< newFlightPathValue) {
		i++;
		if (flightPath[i] > newFlightPathValue) {
			found = true;
		}
		
	}
	if (found) {
		//f(b) = f(a) + ((b - a)/(c - a))(f(c) - f(a))
		//return 0;
		return coefficientOfLift[i - 1] + ((newFlightPathValue - flightPath[i-1]) / (flightPath[i] - flightPath[i-1]))*(coefficientOfLift[i] - coefficientOfLift[i - 1]);
	}
 	return 0;
}
bool isOrdered(const vector <double> &flightPath) {
	for (unsigned i = 0; i+1 < flightPath.size(); ++i)
	{
		if (flightPath[i] > flightPath[i + 1]) {
			return false;
		}
	}
	/*if(flightPath.size()==0){
		return false;
	}*/
	return true;
}
void reorder(vector <double> &flightPath, vector <double> &coefficientOfLift) {
	bool tabInOrder = false;
	unsigned  tmp = flightPath.size();
	//if(flightPath.size()!=0){
	while (!tabInOrder)
	{
		tabInOrder = true;
		for (unsigned int i = 0; i < tmp - 1; i++)
		{
			if (flightPath[i] > flightPath[i + 1])
			{
				swap(flightPath[i], flightPath[i + 1]);
				swap(coefficientOfLift[i], coefficientOfLift[i + 1]);
				tabInOrder = false;
			}
		}
		tmp--;
	//}
}
}
void swap(double &a, double &b) {
	double tmp = a;
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

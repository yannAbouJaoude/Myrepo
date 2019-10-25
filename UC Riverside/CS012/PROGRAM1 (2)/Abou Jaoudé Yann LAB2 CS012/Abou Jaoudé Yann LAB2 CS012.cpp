// Abou Jaoudé Yann LAB2 CS012.cpp 
#include "stdafx.h"
#include <iostream>
#include <cstdlib>
//#include <cmath>
//#include <ctime>
#include <vector>
#include <string>
#include <fstream>

using namespace std;

int fileSum(string filename);
void LAB2_1fileSumMain();
void LAB2_2CountingCharacterMain();
int charCnt(string filename, char ch);
void LAB2_3GapToTheAverageMain();

int main() {
	cout << endl << "---------- LAB 2.1 File sum ----------" << endl;
    LAB2_1fileSumMain();
	cout << endl << "---------- LAB 2.2 Counting Character ----------" << endl;
    LAB2_2CountingCharacterMain();
	cout << endl << "---------- LAB 2.3 Gap to the Average ----------" << endl;
	LAB2_3GapToTheAverageMain();
	system("PAUSE");
	return 0;
}
void LAB2_1fileSumMain() {
	string filename;
	cout << "Enter the name of the input file: ";
	//cin >> filename;
	cin >> filename;
	cout << endl;
	cout << "Sum: " << fileSum(filename) << endl;
}
int fileSum(string filename) {
	ifstream file(filename.c_str(), ios::in); 
	if (file) 
	{
		string number="0";
		int sum=0;
		char myChar;  
		while (file.get(myChar)) {
			cout << myChar;
			if (isdigit(myChar)) {
				number += myChar;
			}
			else {
				sum += stoi(number);
				number = "0";
			}
		}
		sum += stoi(number);
		cout << endl;
		file.close();  
		return sum;
	}
	else 
	{
		cerr << "Error.Error.Error.File not found." << endl;
		return -1;
	}
}

void LAB2_2CountingCharacterMain(){
	string filename;
	char ch;
	cout << "Enter the name of the input file: ";
	cin >> filename;
	cout << endl;
	cout << "Enter a character: ";
	cin.ignore();
	cin.get(ch);
	cout << endl;

	cout << "# of " << ch << "'s: " << charCnt(filename, ch) << endl;
}
int charCnt(string filename, char ch) {
	ifstream file(filename.c_str(), ios::in);
	if (file)
	{
		int count = 0;
		char myChar;
		while (file.get(myChar)) {
			cout << myChar;
			if (myChar==ch) {
				count++;
			}
		}
		cout << endl;
		file.close();
		return count;
	}
	else
	{
		cerr << "Error.Error.Error.File not found." << endl;
		return -1;
	}
}

void LAB2_3GapToTheAverageMain() {
	string inputFile;
	string outputFile;

	cout << "Enter name of input file: ";
	cin >> inputFile;
	cout << endl;

	cout << "Enter name of output file: ";
	cin >> outputFile;
	cout << endl;
	vector <double> myVector;

	ifstream file(inputFile.c_str(), ios::in);
	if (file)
	{
		string number = "0";
		bool precedentCharIsDigit = false;
		char myChar;
		while (file.get(myChar)) {
			cout << myChar;
			if (isdigit(myChar)) {
				number += myChar;
				precedentCharIsDigit = true;
			}
			else if (precedentCharIsDigit) {
				myVector.push_back(stoi(number));
				precedentCharIsDigit = false;
				number = "0";
			}
		}
		if (precedentCharIsDigit) {
			myVector.push_back(stoi(number));
		}
		cout << endl;
		file.close();
	}
	else
	{
		cerr << "Error.Error.Error.File not found." << endl;
	}
	double average = 0;
	for (int i = 0; i < myVector.size(); i++)
	{
		cout << myVector[i] << endl;
		average = average + myVector[i] / myVector.size();
	}
	cout << average << endl;
	for (int i = 0; i < myVector.size(); i++)
	{
		myVector[i] = sqrt(pow(myVector[i] - average,2));
		cout << myVector[i] << endl;
	}
	ofstream exitFile(outputFile, ios::out | ios::trunc);  
	if (exitFile)
	{
		for (int i = 0; i < myVector.size(); i++)
		{
			exitFile << myVector[i] << ",";
		}
	}
	else 
	{
		cerr << "Impossible d'ouvrir le fichier !" << endl;
	}
	// Write doubled values into ouptut csv file, each integer separated by a comma.
}

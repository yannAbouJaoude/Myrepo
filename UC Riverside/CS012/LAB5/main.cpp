#include <iostream>

using namespace std;

double mean(const double array[], int arraySize);
void remove(double array[], int &arraySize, int index);
void display(const double array[], int arraySize);

int main(){
	int arraySize=10;
	double myArray[arraySize];
	cout<<"Enter "<<arraySize<<" values:"<<endl;
	for(int i=0; i< arraySize; i++){
		cin>>myArray[i];
	}
	cout<<endl<<"Mean: "<<mean(myArray,arraySize)<<endl<<endl<<"Enter index of value to be removed: "<<endl;
	int index;
	cin>>index;
	cout<<"Before removing value: ";
	display(myArray,arraySize);
	remove(myArray,arraySize,index);
	cout<<"After removing value: ";
	display(myArray,arraySize);
}

double mean(const double array[], int arraySize){
	double result=0;
	for(int i=0; i<arraySize;i++){
		result+=array[i]/arraySize;
	}
	return result;
}
void remove(double array[], int &arraySize, int index){
	arraySize--;
	for(int i=index; i<arraySize;i++){
		array[i]=array[i+1];
	}
}
void display(const double array[], int arraySize){
	for(int i=0; i<arraySize-1;i++){
		cout<<array[i]<<", ";
	}
	cout<<array[arraySize-1]<<endl;
}
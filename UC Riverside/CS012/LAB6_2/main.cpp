#include <iostream>
#include "IntVector.h"
using namespace std;

int main() {
	IntVector a;
	IntVector b(5,4);
	int test;
	cout<<"size of a: "<<a.size()<<endl;
	cout<<"size of b: "<<b.size()<<endl;
	cout<<"capacity of a: "<<a.capacity()<<endl;
	cout<<"capacity of b: "<<b.capacity()<<endl;
	cout<<"Is empty a: "<<a.empty()<<endl;
	cout<<"Is empty b: "<<b.empty()<<endl;
	cout<<"Trying a.at(-1) :"<<endl;
	test=a.at(-1);
	cout<<"Trying a.at(1) :"<<endl;
	test=a.at(1);
	cout<<"Trying b.at(0) :"<<endl;
	test=a.at(0);
	cout<<"test: "<<test <<endl;
	cout<<"Trying b.at(3) :"<<endl;
	test=a.at(3);
	cout<<"test: "<<test <<endl;
	cout<<"Trying b.front() :"<<endl;
	test=b.front();
	cout<<"Trying b.back() :"<<endl;
	test=b.back();
	/*
	cout<<"Trying b.front() after deleting b:"<<endl;
	delete b;
	test=b.front();
	*/ 
	//fail

	return 0;
}

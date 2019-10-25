#include <iostream>
#include "IntVector.h"
using namespace std;

int main() {
	IntVector a;
	IntVector b(5,4);
	int test1;
	unsigned test2;
	bool test3;
	

	//successful tests on a
	test2=a.size();
    test2=a.capacity();
    test3=a.empty();
    test1=a.at(0);
    a.at(0)=5;
    a.at(0)=-1;
    a.insert(0, 1);
    a.insert(1, 1);
    a.clear();
    a.insert(0, -1);
    a.insert(1, -1);
    a.erase(0);
    test1=a.front();
    a.front()=5;
    a.front()=-1;
    test1=a.back();
    a.back()=5;
    a.back()=-1;
    a.assign(0, 1);
    a.push_back(5);
    a.pop_back();
    a.clear();
    a.resize(5);
    a.resize(6,1);
    a.resize(4,2);
    a.reserve(7);
    a.reserve(5);

    //successful tests on b
    test2=b.size();
    test2=b.capacity();
    test3=b.empty();
    test1=b.at(0);
    b.at(0)=5;
    b.at(0)=-1;
    b.insert(0, 1);
    b.insert(1, 1);
    b.clear();
    b.insert(0, -1);
    b.insert(1, -1);
    b.erase(0);
    test1=b.front();
    b.front()=5;
    b.front()=-1;
    test1=b.back();
    b.back()=5;
    b.back()=-1;
    b.assign(0, 1);
    b.push_back(5);
    b.pop_back();
    b.resize(5);
    b.resize(6,1);
    b.resize(4,2);
    b.reserve(7);
    b.reserve(5);
    b.clear();
    b.resize(5,3);
    delete &b;
    
	cout<<test1<<" "<<test2<<" "<<test3<<endl;

	return 0;
}

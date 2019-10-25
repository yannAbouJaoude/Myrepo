#include <iostream>
#include "IntList.h"

using namespace std;

class SortedSet: public IntList {
	public:
	SortedSet();
	SortedSet(const SortedSet &);
	SortedSet(const IntList &);
	//~SortedSet();
	
	void add(int data);
	void push_front(int data);
	void push_back(int data);
	void insert_ordered(int data);

	bool in(int data);
	SortedSet &operator|:(const SortedSet &rhs1,const SortedSet &rhs2);
	SortedSet &operator&(const SortedSet &rhs1,const SortedSet &rhs2);

	SortedSet & operator|=(const SortedSet &rhs);
	SortedSet & operator&=(const SortedSet &rhs);

 };

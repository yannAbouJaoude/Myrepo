#include <iostream>
using namespace std;


struct IntNode {
    int data;
    IntNode *next;
    IntNode(int data) : data(data), next(0) {}
};


class IntList {
	private:
    IntNode* head;
    IntNode* tail;
	public:

    IntList();// Initializes an empty list.
    ~IntList();// Deallocates all remaining dynamically allocated memory (all remaining IntNodes).
    void display() const;// Displays to a single line all of the int values stored in the list, each separated by a space. This function does NOT output a newline or space at the end.
    void push_front(int value);// Inserts a data value (within a new node) at the front end of the list.
    void pop_front();// Removes the value (actually removes the node that contains the value) at the front end of the list. Does nothing if the list is already empty.
    bool empty() const;// Returns true if the list does not store any data values (does not have any nodes), otherwise returns false.
    const int & front() const;// Returns a reference to the first value in the list. Calling this on an empty list causes undefined behavior.
    const int & back() const;// Returns a reference to the last value in the list. Calling this on an empty list causes undefined behavior.


};
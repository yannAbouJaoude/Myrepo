#include <iostream>
#include "IntList.h"
using namespace std;

IntList::IntList(){
	this->head=nullptr;
	this->tail=nullptr;
}

bool IntList::empty() const{
	if(this->head==nullptr){
		return true;
	}
	return false;
}
void IntList::push_front(int value){
	IntNode* node = new IntNode(value);
   // node->data = value;
    node->next = this->head;
	this->head = node;
	if(this->tail==nullptr){
		this->tail = node;
	}
}
void IntList::pop_front(){
	if(!empty()){
        IntNode *n = head;
        head = head->next;
        delete n;
    }
}
const int & IntList::front() const{
	return (this->head)->data;
}
const int & IntList::back() const{
	return (this->tail)->data;
}
void IntList::display() const{
	if(!empty()){
		IntNode* currObj = this->head;                
	    while (currObj != this->tail) {
	    	cout<<currObj->data<<" ";
	      	currObj = currObj->next;
	    }
	    cout<<(this->tail)->data;
	}
}
IntList::~IntList(){
 	IntNode *ptr;
    for (ptr = head; head; ptr = head)
    {
    	head = head->next;
     	delete ptr;
    }
 }
#include <iostream>
#include "IntList.h"
using namespace std;

IntList::IntList(){
	this->head=nullptr;
}
void IntList::push_front(int value){
	IntNode* node = new IntNode(value);
    node->next = this->head;
	this->head = node;
	node->data=value;
}
bool IntList::exists(int value) const{
	IntNode* currObj = this->head;   


	    if (currObj == nullptr) 
	    {
	    	return false;
	    }
	    else
	    {
	    	if(currObj->data==value){
	    		return true;
	    	}
	      	return exists(currObj->next, value);
	    }	    
}
bool IntList::exists(IntNode *a, int value) const{
	IntNode* currObj = a;                
	   if (currObj == nullptr) 
	    {
	    	return false;
	    }
	    else{
	    	if(currObj->data==value){
	    		return true;
	    	}
	      	return exists(currObj->next, value);
	    }
}
ostream & operator<<(ostream &out, const IntList &rhs){
	IntNode* currObj = rhs.head;                
	if(currObj == nullptr){
		return out;
	}
	else
	{
		out<<currObj->data;
		out<<( currObj->next);
		return out;
	}
}
ostream & operator<<(ostream &out, IntNode *currObj){
	if(currObj == nullptr){
		return out;
	}
	else
	{
		out<<" "<<currObj->data;
		out<<( currObj->next);
		return out;
	}
}
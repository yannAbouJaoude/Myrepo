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
void IntList::push_back(int value){
 	if(empty()){
 		push_front(value);
 	}
 	else{
 		IntNode* node = new IntNode(value);
 		tail->next=node;
 		//node=tail;
 		tail=node;
 	}
}
void IntList::clear(){
 	IntNode *ptr;
    for (ptr = head; head; ptr = head)
    {
    	head = head->next;
     	delete ptr;
    }
 	this->head=nullptr;
	this->tail=nullptr;
}
void IntList::remove_duplicates(){
	IntNode* currObj1 = this->head;     
	IntNode* prevObj;
	int tmp;
	bool found = false; 
	if(!(empty())&&!(this->head==this->tail)){
		if((this->head->next==this->tail)&&(this->head->data==this->tail->data)){
			this->head->next=nullptr;
			this->tail=this->head;
		}
		else if((this->head->data==this->head->next->data)&&(this->head->data==this->head->next->next->data)&&this->head->next->next==this->tail){
			this->head->next=nullptr;
			this->tail=this->head;
		}
	 	else{
			while (currObj1 != this->tail) {
				tmp=currObj1->data;
				prevObj=currObj1;
				currObj1 = currObj1->next;
				IntNode* currObj2 = currObj1;

				while (currObj2 != this->tail) {
			    	if(currObj2->data==tmp){
			    		prevObj->next=prevObj->next->next;
			    		found = true;
			    	}	    	
			    	prevObj=currObj2;
			    	currObj2 = currObj2->next;
				}
				if(currObj2->data==tmp){
					this->tail=prevObj;
			    	prevObj->next=nullptr;
			    }
			}	
		}	
	}
	if(found){
		remove_duplicates();
	}
}
void IntList::selection_sort(){
	if(!empty()){
		IntNode* currObj = this->head;  
		int size=1;          
	    while (currObj != this->tail) {
	    	size++;
	      	currObj = currObj->next;
	    }
	    
	    for(int i=0;i<size;i++)
	    {
	    	currObj = this->head;
	    	while (currObj != this->tail) {
		    	if(currObj->data>currObj->next->data){
		    		int tmp=currObj->data;
		    		currObj->data=currObj->next->data;
		    		currObj->next->data=tmp;
		    	}
	      		currObj = currObj->next;
	    	}
	    }
	}	
}
void IntList::insert_ordered(int value){
	push_front(value);
	selection_sort();
};

IntList::IntList(const IntList &cpy){
    
    if(cpy.empty()){
    	this->head = nullptr;
    	this->tail = nullptr;
    }
    else{
    	IntNode* currObj = cpy.head;    
    	IntNode* newObj;
    	IntNode* lastObj;
    	newObj=new IntNode(currObj->data);
    	this->head=newObj;
    	lastObj=newObj;
	    while (currObj != cpy.tail) {
	    	currObj = currObj->next;
	    	newObj=new IntNode(currObj->data);
	    	lastObj->next=newObj;
	    	lastObj=newObj;
	    }
	    this->tail=lastObj;
    }
}
IntList & IntList::operator=(const IntList &rhs){
	if(this->head!=rhs.head){
		this->~IntList();
		if(rhs.empty()){
	    	this->head = nullptr;
	    	this->tail = nullptr;
	    }
	    else{
	    	IntNode* currObj = rhs.head;    
	    	IntNode* newObj;
	    	IntNode* lastObj;
	    	newObj=new IntNode(currObj->data);
	    	this->head=newObj;
	    	lastObj=newObj;
		    while (currObj != rhs.tail) {
		    	currObj = currObj->next;
		    	newObj=new IntNode(currObj->data);
		    	lastObj->next=newObj;
		    	lastObj=newObj;
		    }
		    this->tail=lastObj;
	    }
	}
	return*this;
}
ostream & operator<<(ostream &out, const IntList &rhs){
	if(!(rhs.empty())){
		IntNode* currObj = rhs.head;                
	    while (currObj != rhs.tail) {
	    	out<<currObj->data<<" ";
	      	currObj = currObj->next;
	    }
	    out<<(rhs.tail)->data;
	}
	return out;
}
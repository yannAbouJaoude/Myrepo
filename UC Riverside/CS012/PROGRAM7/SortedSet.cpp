#include <iostream>
#include "SortedSet.h"
using namespace std;

SortedSet::SortedSet():IntList(){}
SortedSet::SortedSet(const SortedSet &mySortedSet):IntList(){
	IntNode* currObj1 = mySortedSet.head; 
	IntNode* copyObj1=new IntNode(currObj1->data); 
	//copyObj1->data=currObj1->data;
	this->head=copyObj1;
	while(currObj1->next!=nullptr){
		currObj1 = currObj1 ->next;
		copyObj1 = copyObj1 ->next;
		copyObj1->data=currObj1->data;
	}
	this->tail=copyObj1;
	this->tail->next=nullptr;
}
SortedSet::SortedSet(const IntList &myList):IntList(){
	remove_duplicates();
	selection_sort();
	IntNode* currObj1 = myList.head; 
	IntNode* copyObj1=new IntNode(currObj1->data); 
	this->head=copyObj1;
	
	while(currObj1->next!=nullptr){
		currObj1 = currObj1 ->next;
		copyObj1 = copyObj1 ->next;
		copyObj1->data=currObj1->data;
	}
	this->tail=copyObj1;
	this->tail->next=nullptr;
}

void SortedSet::add(int data){
	if(!empty()){
		IntNode* currObj = this->head; 
		while(currObj->data<data&&currObj->next!=nullptr){
			currObj=currObj->next;
		}
		if(currObj->data!=data){
			IntNode* tmp =new IntNode(data);
			tmp->next=currObj->next;
			currObj->next=tmp;
		}
	}
	else{
		this->head=new IntNode(data);
		this->tail=this->head;
	}
}
void SortedSet::push_front(int data){
	this->add(data);
}
void SortedSet::push_back(int data){
	this->add(data);
}
void SortedSet::insert_ordered(int data){
	this->add(data);
}

SortedSet & SortedSet::operator|=(const SortedSet &rhs){
	if(this->head!=rhs.head){
		return *this;
	}
	else{
		IntNode* currObj1 = rhs.head; 		
		while(currObj1->next!=nullptr){
			currObj1=currObj1->next;
			this->add(currObj1->data);
		}
		this->add(currObj1->data);
		return *this;
	}
}
SortedSet & SortedSet::operator&=(const SortedSet &rhs){
	if(this->head!=rhs.head){
		return *this;
	}
	else{
		IntNode* currObj1 = this->head;
		IntNode* currObj2 = rhs.head;
		IntNode* prevObj1 = this->head->next;

		while(currObj2!=nullptr&&currObj1!=nullptr){
			if(currObj2->data<currObj1->data){
				currObj2=currObj2->next;
			}
			else if(currObj2->data==currObj1->data){
				currObj2=currObj2->next;
				prevObj1=currObj1;
				currObj1=currObj1->next;
			}
			else{
				if(currObj1==this->head){
					this->head=this->head->next;
					currObj1 = this->head;
				}
				else{
					prevObj1->next=currObj1->next;				
					currObj1=currObj1->next;
				}
			}
		}
		return *this;
	}
}



#include <iostream>
#include <stdexcept>
#include "IntVector.h"
using namespace std;

IntVector::IntVector(){
	this->sz=0;
	this->cap=0;
	data = new int[0];
}
IntVector::IntVector(unsigned size, int value){
 	this->sz=size;
	this->cap=size;
	data = new int[size];
	for(unsigned  i=0; i<size;i++){
		data[i]=value;
	}
}
IntVector::~IntVector(){
	delete data;
}
unsigned IntVector::size() const{
	return this->sz;
}
unsigned IntVector::capacity() const{
	return this->cap;
}
bool IntVector::empty() const{
	if(this->sz>0){
		return false;
	}
	else{
		return true;
	}
}
const int & IntVector::at(unsigned index) const{
 	if(index>=0&&index<this->sz){
 		return this->data[index];
 	}
 	else{
 		throw out_of_range("IntVector::at_range_check");
 	}
 }
const int & IntVector::front() const{
	return this->data[0];
}
const int & IntVector::back() const{
	return this->data[this->sz -1];
}
void IntVector::expand(){
	if(this->cap==0){
		this->cap++;
	}
	else{
		int *tmp=this->data;
		int tmpcap=this->cap;
		this->data=new int[this->cap*2];
		this->cap=this->cap*2;
		for(int i=0;i<tmpcap;i++){
			this->data[i]=tmp[i];
		}
		delete tmp;
	}
}
void IntVector::expand(unsigned amount){
	int *tmp=this->data;
	int tmpcap=this->cap;
	this->data=new int[this->cap+amount];
	this->cap=this->cap+amount;
	for(int i=0;i<tmpcap;i++){
		this->data[i]=tmp[i];
	}
	delete tmp;
}
void IntVector::insert(unsigned index, int value){
	if(index>=0&&index<this->sz+1){
 		if(this->cap==this->sz){
			this->expand();
		}
		for(unsigned i = this->sz; i>index;i--){
			this->data[i]=this->data[i-1];
		}
		this->data[index]=value;
		this->sz++;
 	}
 	else{
 		throw out_of_range("IntVector::insert_range_check");
 	}
}
void IntVector::erase(unsigned index){
	if(index>=0&&index<this->sz){
		for(unsigned i = index; i<this->sz-1 ;i++){
			this->data[i]=this->data[i+1];
		}
	
		this->sz--;
 	}
 	else{
 		throw out_of_range("IntVector::erase_range_check");
 	}
}
void IntVector::push_back(int value){
	if(this->cap==this->sz){
		this->expand();
	}
	this->data[this->sz]=value;
	this->sz++;
}
void IntVector::pop_back(){
	this->sz--;
}
void IntVector::clear(){
	this->sz=0;
}
void IntVector::resize(unsigned size, int value){
	if(this->cap<size){
		if(this->cap*2>size){
			expand();
		}
		else{
			expand(size - cap);
		}
	}
	for(unsigned i=this->sz;i<size;i++){
		this->data[i]=value;
	}
	this->sz=size;
}
void IntVector::reserve(unsigned n){
	if(this->cap<n){
		expand(n-this->cap);
	}
}
int & IntVector::back(){
	return this->data[this->sz -1];
}
int & IntVector::front(){
	return this->data[0];
}
int & IntVector::at(unsigned index){
	if(index>=0&&index<this->sz){
 		return this->data[index];
 	}
 	else{
 		throw out_of_range("IntVector::at_range_check");
 	}
}
void IntVector::assign(unsigned n, int value){
	if(this->cap<n){
		if(this->cap*2>n){
			expand();
		}
		else{
			expand(n - cap);
		}
	}
	for(unsigned i =0; i<n;i++){
		this->data[i]=value;
	}
	this->sz=n;
}








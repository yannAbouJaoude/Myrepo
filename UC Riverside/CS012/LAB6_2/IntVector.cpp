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

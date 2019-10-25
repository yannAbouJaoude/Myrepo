#include <iostream>
#include "Distance.h"
using namespace std;

Distance::Distance(){
	this->feet=0;
	this->inches=0;
}
Distance::Distance(unsigned ft, double in){
	this->feet=ft;
	this->inches=in;
	init();
}
Distance::Distance(double in){
	this->feet=0;
	this->inches=in;
	init();
}
unsigned Distance::getFeet() const{
	return this->feet;
}
double Distance::getInches() const{
	return this->inches;
}
double Distance::distanceInInches() const{
	return this->inches+this->feet*12;
}
double Distance::distanceInFeet() const{
	return ((double)this->inches)/12+this->feet;
}
double Distance::distanceInMeters() const{
	return (double)this->inches*0.0254+this->feet*0.3048;
}
const Distance Distance::operator+(const Distance &rhs) const{
	Distance tmp(this->feet+rhs.getFeet(),this->inches+rhs.getInches());
	return tmp;
}
const Distance Distance::operator-(const Distance &rhs) const{
	unsigned feetTmp;
    double inchesTmp;
	if(this->feet>rhs.getFeet()){
		feetTmp=this->feet-rhs.getFeet();
		inchesTmp=this->inches-rhs.getInches();
		if(inchesTmp<0){
			feetTmp=feetTmp-1;
			inchesTmp=inchesTmp+12;
		}
	}
	else if(this->feet<rhs.getFeet()){
		feetTmp=rhs.getFeet()-this->feet;
		inchesTmp=rhs.getInches()-this->inches;
		if(inchesTmp<0){
			feetTmp=feetTmp-1;
			inchesTmp=inchesTmp+12;
		}
	}
	else{
		if(this->feet>rhs.getFeet()){
		Distance tmp(this->feet-rhs.getFeet(),this->inches-rhs.getInches());
		}
		else{
			Distance tmp(rhs.getFeet()-this->feet,rhs.getInches()-this->inches);
		}
	}
	Distance tmp(feetTmp,inchesTmp);
	return tmp;
}	
ostream &operator<<(ostream &out, const Distance &rhs){
out<<rhs.getFeet()<<"' "<<rhs.getInches()<<"\"";
return out;
}

void Distance::init(){
	while(this->inches<0){
		this->inches=0-this->inches;
	}
	if(this->feet<0){
		this->feet=0-this->feet;
	}
	while(this->inches>12){
		this->inches=this->inches-12;
		this->feet=this->feet+1;
	}
}




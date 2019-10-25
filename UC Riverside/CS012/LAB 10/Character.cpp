#include <iostream>
#include <vector>
#include "Character.h"
using namespace std;

Character::Character(HeroType type, const string &name, double health, double attackStrength){
	this->type=type;
	this->name=name;
	this->health=health;
	this->attackStrength=attackStrength;
}
HeroType Character:: getType() const{
	return this->type;
}
const string & Character::getName() const{
	return this->name;
}
int Character::getHealth() const{
	return this->health;
}
void Character:: setHealth(double h){
	this->health=h;
}
     /* Reduces health value by amount passed in. */
void Character:: damage(double d){
	this->health=this->health-d;
	cout<<this->name<<" takes "<<d<<" damage."<<endl;
}
     /* Returns true if getHealth() returns an integer greater than 0, otherwise false */
bool Character:: isAlive() const{
	if(this->health>0){
		return true;
	}
	else{
		return false;
	}
}
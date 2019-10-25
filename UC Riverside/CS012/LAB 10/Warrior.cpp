#include <iostream>
#include <vector>
#include "Warrior.h"
using namespace std;

Warrior::Warrior(const string &name, double health, double attackStrength, string allegiance):Character(WARRIOR,name,health,attackStrength){

	this->allegiance=allegiance;
}

void Warrior::attack(Character &defender){
	
	if(defender.getType()==WARRIOR){
		Warrior &opp = dynamic_cast<Warrior &>(defender);
		this->attack(opp);
	}
	else
	{
		cout<<"Warrior "<<this->name<<" attacks "<<defender.getName()<<" --- SLASH!!"<<endl;
		defender.damage((this->health / MAX_HEALTH)*this->attackStrength);
	}
}

void Warrior::attack(Warrior &defender){

	if(defender.allegiance==this->allegiance){
		cout<<"Warrior "<<this->name<<" does not attack Warrior "<<defender.getName()<<"."<<endl;
		cout<<"They share an allegiance with "<< this->allegiance<<"."<<endl;
	}
	else
	{
		cout<<"Warrior "<<this->name<<" attacks "<<defender.getName()<<" --- SLASH!!"<<endl;
		defender.damage((this->health / MAX_HEALTH)*this->attackStrength);
		
	}
}
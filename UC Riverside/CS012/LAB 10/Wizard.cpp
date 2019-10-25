#include <iostream>
#include <vector>
#include "Wizard.h"
using namespace std;

Wizard::Wizard(const string &name, double health, double attackStrength, int rank):Character(WIZARD,name,health,attackStrength){

	this->rank=rank;
}

void Wizard::attack(Character &defender){
	if(defender.getType()==WIZARD){
		Wizard &opp = dynamic_cast<Wizard &>(defender);
		this->attack(opp);
	}
	else
	{
	cout<<"Wizard "<<this->name<<" attacks "<<defender.getName()<<" --- POOF!!"<<endl;
	defender.damage(this->attackStrength);
	}
}

void Wizard::attack(Wizard &defender){
	
	cout<<"Wizard "<<this->name<<" attacks "<<defender.getName()<<" --- POOF!!"<<endl;
	defender.damage(this->rank*this->attackStrength / defender.rank);
		
	
}
#include <iostream>
#include <vector>
#include "Elf.h"
using namespace std;
Elf::Elf(const string &name, double health, double attackStrength, string familyName):Character(ELF,name,health,attackStrength){

	this->familyName=familyName;
}
void Elf::attack(Character &defender){
	if(defender.getType()==ELF){
		Elf &opp = dynamic_cast<Elf &>(defender);
		this->attack(opp);
	}
	else
	{
	cout<<"Elf "<<this->name<<" shoots an arrow at "<<defender.getName()<<" --- TWANG!!"<<endl;
	defender.damage((this->health / MAX_HEALTH)*this->attackStrength);
	}
}

void Elf::attack(Elf &defender){
	
	if(defender.familyName==this->familyName){
		cout<<"Elf "<<this->name<<" does not attack Elf "<<defender.getName()<<"."<<endl;
		cout<<"They are both members of the "<< this->familyName<<" family."<<endl;
	}
	else
	{
		cout<<"Elf "<<this->name<<" shoots an arrow at "<<defender.getName()<<" --- TWANG!!"<<endl;
		defender.damage((this->health / MAX_HEALTH)*this->attackStrength);
		
	}
}
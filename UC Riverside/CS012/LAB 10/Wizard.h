#include <iostream>
#include <vector>
#include "Character.h"
using namespace std;

class Wizard : public Character { 
public:
	int rank;
    Wizard(const string &name, double health, double attackStrength, int rank);
    void attack(Character &);
    void attack(Wizard &);
      
   };
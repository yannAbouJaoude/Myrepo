#include <iostream>
#include <vector>
#include "Character.h"
using namespace std;

class Warrior : public Character { 
public:
   string allegiance;
   Warrior(const string &name, double health, double attackStrength, string allegiance);
   void attack(Character &);
   void attack(Warrior &);
      
   };
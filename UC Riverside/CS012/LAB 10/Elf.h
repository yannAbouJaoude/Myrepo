#include <iostream>
#include <vector>
#include "Character.h"
using namespace std;

class Elf : public Character { 
public:
   string familyName;
   Elf(const string &name, double health, double attackStrength, string familyName);
   void attack(Character &);
   void attack(Elf &);
      
   };
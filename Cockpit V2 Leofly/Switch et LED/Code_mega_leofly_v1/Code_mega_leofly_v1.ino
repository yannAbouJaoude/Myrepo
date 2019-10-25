
/* Exemple SeveralMCP23017.pde
   Utilise la librairie Adafruit-MCP23017 pour démontrer l'utilisation de plusieurs MCP23017 sur
   un seul bus I2C. 
   
   Code écrit par Meurisse D. pour MCHobby.be [www.mchobby.be], Licence CC-BY-SA
   
   TUTORIEL complémentaire EN FRANCAIS par MCHobby.be sur (voir wiki pour licence tutoriel)
      http://mchobby.be/wiki/index.php?title=MCP23017

   Acheter un MCP23017
      http://shop.mchobby.be/product.php?id_product=218
*/
   
#include <Wire.h>
#include "Adafruit_MCP23017.h"

// Test de base d'ecriture d'état pour trois "MCP23017 I/O expander" partageant un même bus I2C
//
// Raccordements: http://mchobby.be/wiki/index.php?title=MCP23017-Plusieurs
Adafruit_MCP23017 mcp1;
Adafruit_MCP23017 mcp2;
Adafruit_MCP23017 mcp3;
  
void setup() {
  mcp1.begin(0); // Utilise l'adresse 5 pour IC1
  mcp2.begin(1); // Utilise l'adresse 6 pour IC2
  mcp3.begin(2); // Utilise l'adresse 7 pour IC3

  // Définir la sortie #0 (GPA 0, broche 21) sur IC1 comme sortie
  mcp1.pinMode(0, OUTPUT); 
  // Définir la sortie #1 (GPA 1, broche 22) sur IC2 comme sortie
  mcp2.pinMode(1, OUTPUT); 
  // Définir la sortie #6 (GPA 6, broche 27) sur IC3 comme sortie
  mcp3.pinMode(6, OUTPUT); 
}


// Activer/désactiver la sortie #0 du MCP toutes les 100 millisecondes

void loop() {
  delay(1000); // Attendre 1000ms
  mcp1.digitalWrite(0, HIGH); // Activer sortie sur IC1
  delay(300);
  mcp2.digitalWrite(1, HIGH); // Activer sortie sur IC2
  delay(300);
  mcp3.digitalWrite(6, HIGH); // Activer sortie sur IC3
  
  delay(1000); // Attendre 1s (1000ms)
  mcp1.digitalWrite(0, LOW); // Désactiver sortie sur IC1
  delay(300);
  mcp2.digitalWrite(1, LOW); // Désactiver sortie sur IC2
  delay(300);
  mcp3.digitalWrite(6, LOW); // Désactiver sortie sur IC3
}

/* Exemple button.pde
   Utilise la librairie Adafruit-MCP23017 pour la lecture d'entrée et activation de la Pull-Up sur un MCP23017 I/O expander
   
   Code écrit par LadyAda pour AdaFruit Industries [www.adafruit.com], Domaine Publique
   
   TRADUCTION FRANCAISE par Meurisse D. pour MCHobby.be [www.mchobby.be], CC-BY-SA pour tâche de traduction.
   TUTORIEL complémentaire EN FRANCAIS par MCHobby.be sur (voir wiki pour licence tutoriel)
      http://mchobby.be/wiki/index.php?title=MCP23017

   Acheter un MCP23017
      http://shop.mchobby.be/product.php?id_product=218
*/

#include <Wire.h>
#include "Adafruit_MCP23017.h"
// Test de base de lecture d'entrée (et activation de la Pull-Up) sur un MCP23017 I/O expander
// Domaine Publique! (code d'origine)

// Connectez la broche #12 du MCP23017 sur Arduino broche Analogique A5 (Horloge I2C, SCL)
// Connectez la broche #13 du MCP23017 sur Arduino broche Analogique A4 (Données I2C, SDA)
// Connectez la broche #15, 16 et 17 du MCP23017 sur DNG (Sélection de l'adresse)
// Connectez la broche #9 du MCP23017 sur 5V (Alimentation)
// Connectez la broche #10 du MCP23017 sur GND (Masse commune)

// Entrée #1 (GPA1, broche 22) est connectée sur bouton puis sur la masse 
// par l'intermédiaire d'une résistance de 330 Ohms

// Ajout MCHobby:
// - Connectez la broche #18 du MCP23017 sur 5V (désactiver la ligne Reset)

Adafruit_MCP23017 mcp;
  
void setup() {  
  mcp.begin();      // Utiliser l'adresse par défaut 0x00

  mcp.pinMode(1, INPUT); // Activer GPA1 comme entrée
  mcp.pullUp(1, HIGH);   // Activer la résistance Pull-Up interne de 100K

  pinMode(13, OUTPUT);  // Utiliser la LED sur la Broche 13 pour faire du débogage.
}



void loop() {
 // Serial.println(mcp.digitalRead(1));
  // La LED 'rapporte' l'état de l'entrée du MCP
  digitalWrite(13, mcp.digitalRead(1));
}

#include <Keyboard.h>;
  int i = 1;
void setup()
{
  Serial.begin(9600);
  Serial.print("Bonjour !");
  Keyboard.begin();
while(i<300){
  
  Serial.print("Bonjour !");
 Keyboard.press(81); // i
  delay(10);
  Keyboard.release(81);
  Keyboard.press(76); // i
  delay(10);
  Keyboard.release(76);
   Keyboard.press(73); // i
  delay(10);
  Keyboard.release(73);
   Keyboard.press(88); // i
  delay(10);
  Keyboard.release(88);
  Keyboard.press(176); // i
  delay(10);
  Keyboard.release(176);
  
  delay(50);
  i++;}
}

void loop()
{
  
}

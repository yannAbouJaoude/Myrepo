#include <Keyboard.h>;
  double valeurGaz = 0;
  double temps;
  double positionCockpit;
  double positionTheorique;
  double tempsRetour;
void setup()
{
  delay(100000);
  Serial.begin(9600);
  Serial.print("Bonjour !");
  Keyboard.begin();

}

void loop()
{
  
  valeurGaz = map(analogRead(0),0,5,0,160);
  if(valeurGaz<5){
    Keyboard.press(214); // i
    delay(200);
    Keyboard.release(214);
    positionTheorique=0;
  }
  else
  {
    temps = valeurGaz-positionCockpit;
    if(temps>100)
    {
    temps=100;
    }
    else if(temps<100)
    {
    temps=-100;;
    }
    if(temps>0)
    {
      if(positionTheorique<1600)
      {
        Keyboard.press(43);
        delay(temps);
        Keyboard.release(43);
        delay(tempsRetour);
        if(positionTheorique+temps<1600)
        {
          positionTheorique=positionTheorique+temps;
        }
        else
        {
          positionTheorique=1600;
        }
      }
    }
    else
    {
      if(positionTheorique>0)
      {
        Keyboard.press(54);
        delay(temps);
        Keyboard.release(54);
        delay(tempsRetour);
        if(positionTheorique-temps>0)
        {
          positionTheorique=positionTheorique-temps;
        }
        else
        {
          positionTheorique=0;
        }
      }
    }
  }
}

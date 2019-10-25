#include <Servo.h>
Servo salut4;
Servo salut1;
Servo salut2;
Servo salut3;
void setup() {
  // put your setup code here, to run once:

salut1.attach(8);
salut2.attach(5);
salut3.attach(10);
salut4.attach(11);

}
void bougerDoucement(Servo servo, int positionprecedente , int nouvelleposition)
{
  while(positionprecedente>nouvelleposition){
    positionprecedente=positionprecedente-1;
    servo.write(positionprecedente);
    delay(10);
  }
  while(positionprecedente<nouvelleposition){
    positionprecedente=positionprecedente+1;
    servo.write(positionprecedente);
    delay(10);
  }  
}
void loop() {
  // put your main code here, to run repeatedly:

bougerDoucement(salut3,45,0);
delay(100);
bougerDoucement(salut1,45,0);
delay(100);
bougerDoucement(salut2,0,45);
delay(100);
bougerDoucement(salut4,180,20);
delay(100);
bougerDoucement(salut3,0,45);
delay(100);
bougerDoucement(salut1,0,45);
delay(100);
bougerDoucement(salut4,20,45);
delay(100);
bougerDoucement(salut3,45,90);
delay(100);
bougerDoucement(salut1,45,90);
delay(100);
bougerDoucement(salut2,45,0);
delay(100);
bougerDoucement(salut4,45,90);
delay(100);
bougerDoucement(salut3,90,135);
delay(100);
bougerDoucement(salut1,90,135);
delay(100);
bougerDoucement(salut4,90,135);
delay(100);
bougerDoucement(salut3,135,90);
delay(100);
bougerDoucement(salut1,135,90);
delay(100);
bougerDoucement(salut2,0,45);
delay(100);
bougerDoucement(salut4,135,90);
delay(100);
bougerDoucement(salut3,90,45);
delay(100);
bougerDoucement(salut1,90,45);
delay(100);
bougerDoucement(salut2,45,0);
delay(100);
bougerDoucement(salut4,90,45);
delay(100);
bougerDoucement(salut4,45,180);
delay(100);
}

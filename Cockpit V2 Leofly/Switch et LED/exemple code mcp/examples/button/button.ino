#include <Servo.h> // on inclue la bibliotheque
int pinServo = 11; 
Servo leServo; // nomme le servo
int nb =5; // on rentre le nombre de disque 
//int tour45= 10000-(nb*1000)+1000; // variable pour la fonction monté decsendre avec maximum 10 disque et une barre de 10 cm
//int tour90= 10000;
//int tour135= 10000;
int WCduFSR = 10;
int compteurFSR;
int PLS=0; // variable pour la vitesse
  Servo servoPince;
  Servo Monter;
void setup() { 
  Serial.begin(9600); // pour le moniteur de serie  // pour faire marcher le moniteur serie
  Serial.println("bonjour"); // aficher bonjour et ln pour alle a la ligne 
 servoPince.attach(13);
 Monter.attach(9);
 pinMode(A1,INPUT);
 pinMode(10,INPUT);
  // put your setup code here, to run once:
leServo.attach(pinServo);// on associe le servo leServo au pin de la variable pinServo
leServo.write(PLS); // le servo ce positionne a la donné de pls c'est la fonction .write
            tours(45, 135, 90, nb); // initialise la fonction
} 


        void tours(int deplacement, int destination, int echange, int n) // 'description' de la fonction tour
        {
            if (n == 1){ // debut du programme pour resoudre la tour de hanoii 
               Serial.print( " déplacement ");// affiche le mot deplacement
                 Serial.print(deplacement);// affiche la valeur du deplacement
               
                 Serial.print( " destination ");// affiche le mot destination 
                 Serial.println( destination); // affiche la valeur de la destination 
             PLS = EcrireDansMonCerveau(PLS, deplacement); // on utilise la fonction pour la vitesse qui devient la valeur de pls 
             
            
            delay(2500); // delai entre les fonction
            
            monter(deplacement); // initialise la fonction monter
            
             PLS=EcrireDansMonCerveau(PLS,destination);
             delay(2500);
             pinceOuverte();//servo ouvre pinceç
             delay(2500);
                    
             
             
            delay(2500);
                 
                
            delay(50);}
            else  { // suite du code pour resoudre la tour de hanoii par recurrence
                tours(deplacement, echange, destination, n - 1);   
                tours(deplacement, destination, echange, 1); 
                tours(echange, destination, deplacement, n - 1);   
            }
        }
        int compteur = 0;

            void loop() {
           
            // put your main code here, to run repeatedly:
          }

void monter(int Surqueltourjesuis){ // ' description' de la fonction monter
 
  Monter.write(90);
  compteurFSR=0;
  while (compteurFSR<5) {
   delay(10);
   if (analogRead(A1)>WCduFSR){
    compteurFSR++;}
    else{
      compteurFSR=0;}
  Serial.println(analogRead(A1)); }
Monter.write(45);
delay(1000);
pinceFermer();
delay(1000);
Monter.write(0);
while ( digitalRead(10)!= HIGH){
  delay(5);}
Monter.write(45);
delay(1000);}

// destination au depart  et recommancer void monter
int EcrireDansMonCerveau(int positionDepart, int positionArriver) // ' description' de la fonction pour la vitesse de deplacement
  {
    if(positionDepart<positionArriver){ // on fait deplacer angle par angle avec un faible delay jusqua la position souhaiter depuis la position précedente 
    for ( int position =positionDepart; position<= positionArriver; position ++)
      {
      leServo.write(position);
      //delay(15);
      } 
    }
    else{ // on le refait car position arriver peut etre inferieur a position de depart et inversement donc juste les lognes précedentes ne suffise pas 
    for ( int position = positionDepart; position>=positionArriver; position --)
      {
      leServo.write(position);
      //delay(15);
      } 
    }
    return positionArriver;
  }

void pinceFermer(){ // a faire avec le psr
  
 
  servoPince.write(115);// 0 pas sur c'est pour fermer
  delay(2000);
  }
void pinceOuverte(){

  servoPince.write(179);// 179 pas sur c'est pour ouvrir
  delay(2000);}

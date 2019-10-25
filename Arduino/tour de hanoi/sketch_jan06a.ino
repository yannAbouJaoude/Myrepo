
void setup() {
  // put your setup code here, to run once:
pinMode(8, OUTPUT);
pinMode(9,OUTPUT);
pinMode(10,OUTPUT);
int nb = 8;
            tours('a', 'c', 'b', nb);
} 
        void tours(char deplacement, char destination, char echange, int n)
        {
            if (n == 1)
            {if (destination=='a' || deplacement=='a'){digitalWrite(8,HIGH);}
            else {digitalWrite(8,LOW);}
                if (destination=='b' || deplacement=='b'){digitalWrite(9,HIGH);}
                else {digitalWrite(9,LOW);}
                if (destination=='c' || deplacement=='c'){digitalWrite(10,HIGH);}
                 else {digitalWrite(10,LOW);} 
            delay(500);}
            else
            {
                tours(deplacement, echange, destination, n - 1);   
                tours(deplacement, destination, echange, 1); 
                tours(echange, destination, deplacement, n - 1);   
            }
        }
void loop() {
  // put your main code here, to run repeatedly:


delay(500);
}

#include <iostream>
using namespace std;

bool diophantine(int a, int b, int c, int &x, int &y);
int PGCD(int a, int b);

int main() {

    int a, b, c, x, y;

    cout << "Enter a b c" << endl;
    cin >> a >> b >> c;
    cout << endl;

    cout << "Result: ";
    if (diophantine(a, b, c, x, y)) {
        cout << x << " " << y << endl;
    } else {
        cout << "No solution!" << endl;
    }

    return 0;
}

bool diophantine(int a, int b, int c, int &x, int &y){
    if(!(c%PGCD(a,b)==0)){
        return false;
    }
    else{

        if(a%b==0){
            x = 0;        
            y = c/b;
            return true;
        }
        else
        {
            int u, v;
            diophantine(b, a%b,c, u, v); 
            x = v; 
            y = u-(a/b)*x;      
            return true;           
        }
    }
}

int PGCD(int a, int b){
     return  (b==0)?a:gcd(b,(a%b));
 /*   if(a==b){
        return a;
    }
    else if(a>b){
        return PGCD(a - b, b);
    }
    else{
        return PGCD(a, b - a);
    }*/
}


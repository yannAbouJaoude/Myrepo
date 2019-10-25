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
    if(c!=-1){
        if(c!=PGCD(a,b)){
            int tmp=c/PGCD(a, b);
            if(tmp*PGCD( a, b)==c){
                diophantine( a,  b, PGCD(a, b),  x,  y);
                x=x*tmp;
                y=y*tmp;
                return true;
            }
            else{
                return false;
            }
        }
        else
        {
            diophantine(a, b,-1, x, y); 
            return true;
        }
    }
    else{
        if (a == 0) 
        { 
            x = 0; 
            y = 1; 
            return true;
        } 
        int x1, y1;
        diophantine(b%a, a,-1, x1, y1); 
        x = y1 - (b/a) * x1; 
        y = x1; 
      
        return true; 
            
    }

}

int PGCD(int a, int b){
    if(a==b){
        return a;
    }
    else if(a>b){
        return PGCD(a - b, b);
    }
    else{
        return PGCD(a, b - a);
    }
}


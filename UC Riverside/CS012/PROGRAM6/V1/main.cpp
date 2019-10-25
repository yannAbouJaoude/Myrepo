#include <iostream>
using namespace std;

bool diophantine(int a, int b, int c, int &x, int &y);
int PGCD(int a, int b);
//bool expgcd (int a, int b, int &u, int &v, int s, int t);
bool gcdExtended(int a, int b, int &x, int &y);

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
    else if(a<b){
        diophantine( b, a, PGCD( a,  b),  x,  y);//a toujours plus grand que b
        int tmp = x;
        x=y;
        y=tmp;
        return true;
    }
    else{
     /*   x=1;
        y=0;
        expgcd (a, b, x, y,0,1);*/
        gcdExtended(a, b, x, y);
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



/*bool expgcd (int a, int b, int &u, int &v, int s, int t) {
  int q, r, tmp;
  
  if(b>0){
    q = a / b;
    r = a % b;
    a = b;
    b = r;
    tmp = s;
    s = u - q * s;
    u = tmp;
    tmp = t;
    t = v - q * t;
    v = tmp;
    expgcd (a, b, u, v,s,t);
  }

  return true;
}*/


bool gcdExtended(int a, int b, int &x, int &y) 
{ 
    // Base Case 
    if (a == 0) 
    { 
        x = 0; 
        y = 1; 
        return true;
    } 
    int x1, y1;
    gcdExtended(b%a, a, x1, y1); 
    x = y1 - (b/a) * x1; 
    y = x1; 
  
    return true; 
} 
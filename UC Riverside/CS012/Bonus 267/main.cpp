#include <iostream>
#include <cmath>                   // Note: Needed for math functions in part (3)
using namespace std;

int main() {
   double wallHeight = 0.0;
   double wallWidth  = 0.0;
   double wallArea   = 0.0;
   
   cout << "Enter wall height (feet):" << endl;
   cin  >> wallHeight;
   
   cout << "Enter wall width (feet):" << endl;
   cin  >> wallWidth;
             // FIXME (1): Prompt user to input wall's width
   
   // Calculate and output wall area
   wallArea = wallWidth*wallHeight;                 // FIXME (1): Calculate the wall's area
   cout << "Wall area: "<<wallArea <<" square feet"<<  endl;  // FIXME (1): Finish the output statement
   
   cout << "Paint needed: "<<wallArea/350 <<" gallons"<<endl;
   // FIXME (2): Calculate and output the amount of paint in gallons needed to paint the wall
   cout << "Cans needed: "<<ceil(wallArea/350) <<" can(s)"<< endl;
   // FIXME (3): Calculate and output the number of 1 gallon cans needed to paint the wall, rounded up to nearest integer

   return 0;
}
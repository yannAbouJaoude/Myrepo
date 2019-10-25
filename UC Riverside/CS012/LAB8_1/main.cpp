#include <iostream>
#include <string>

using namespace std;

void flipString(string &s);

int main() {
   string line;
   cout << "Enter a sentence:" << endl;
   getline(cin, line);
   cout << endl;
   cout << line << endl;
   flipString(line);
   cout << line << endl;

   return 0;
}

void flipString(string &s){
	string s1=s.substr(0, s.size()/2);
    string s2=s.substr(s.size()/2, s.size());
	if(s.size() > 2)  
    {
       	flipString(s1);// why does flipString(s.substr(0, s.size()/2) makes an error?
       	flipString(s2);
    }
    s=s2+s1;
}
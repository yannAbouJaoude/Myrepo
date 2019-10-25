#include <iostream>
using namespace std;

class Date {
 private:
   unsigned day;
   unsigned month;
   string monthName;
   unsigned year;

 public:
   // creates the date January 1st, 2000.
   Date();


   Date(unsigned m, unsigned d, unsigned y);
   Date(const string &mn, unsigned d, unsigned y);


   void printNumeric() const;
   void printAlpha() const;
 private:
   bool isLeap(unsigned y) const;
   unsigned daysPerMonth(unsigned m, unsigned y) const;
   string name(unsigned m) const;
   unsigned number(const string &mn) const;
};
//my functions
void Date::printAlpha() const{
	cout<<this->monthName<<" "<<this->day<<", "<<this->year;
}
void Date::printNumeric() const{
	cout<<this->month<<"/"<<this->day<<"/"<<this->year;
}
Date::Date(){
	this->day=1;
   	this->year=2000;
   	this->month=1;
   	this->monthName=name(1);
}
Date::Date(unsigned m, unsigned d, unsigned y){
	this->day=d;
   	this->year=y;
   	this->month=m;
   	bool invalid =false;
   	if(this->year==0){
   		this->year=1;
   		invalid=true;
   	}
   	if(this->month<1){
   		this->month=1;
   		invalid=true;
   	}
   	if(this->month>12){
   		this->month=12;
   		invalid=true;
   	}
   	if(this->day<1){
   		this->day=1;
   		invalid=true;
   	}
   	if(this->day>daysPerMonth(this->month, this->year)){
   		this->day=daysPerMonth(this->month, this->year);
   		invalid=true;
   	}
   	this->monthName=name(this->month);
   	if(invalid){
   		cout<<"Invalid date values: Date corrected to "<<this->month<<"/"<<this->day<<"/"<<this->year<<"."<<endl;
   	}
}
Date::Date(const string &mn, unsigned d, unsigned y){
	this->day=d;
   	this->year=y;
   	this->month=number(mn);
   	bool invalid =false;

   	if(this->month==0){
   		cout<<"Invalid month name: the Date was set to 1/1/2000."<<endl;
   		this->day=1;
   		this->month=1;
   		this->year=2000;
   	}
   	if(this->year==0){
   		this->year=1;
   		invalid=true;
   	}
   	if(this->day<1){
   		this->day=1;
   		invalid=true;
   	}
   	if(this->day>daysPerMonth(this->month, this->year)){
   		this->day=daysPerMonth(this->month, this->year);
   		invalid=true;
   	}
   	this->monthName=name(this->month);
   	if(invalid){
   		cout<<"Invalid date values: Date corrected to "<<this->month<<"/"<<this->day<<"/"<<this->year<<"."<<endl;
   	}
}
bool Date::isLeap(unsigned y)const{
	if(y%4==0&&(y%100!=0||y%400==0)){
		return true;
	}
	else{
		return false;
	}
}
unsigned Date::daysPerMonth(unsigned m, unsigned y) const{
	if(m==4||m==6||m==9||m==11){
		return 30;
	}
	else if(m==2){
		if (this->isLeap(y)){
			return 29;
		}
		else{
			return 28;
		}
	}
	else{
		return 31;
	}
}
string Date::name(unsigned m) const{
	if(m==1){
		return "January";
	}
	else if(m==2){
		return "February";
	}
	else if(m==3){
		return "March";
	}
	else if(m==4){
		return "April";
	}
	else if(m==5){
		return "May";
	}
	else if(m==6){
		return "June";
	}
	else if(m==7){
		return "July";
	}
	else if(m==8){
		return "August";
	}
	else if(m==9){
		return "September";
	}
	else if(m==10){
		return "October";
	}
	else if(m==11){
		return "November";
	}
	else {
		return "December";
	}
}
unsigned Date::number(const string &mn) const{
	if(mn=="January"||mn=="january"){
		return 1;
	}
	else if(mn=="February"||mn=="february"){
		return 2;
	}
	else if(mn=="March"||mn=="march"){
		return 3;
	}
	else if(mn=="April"||mn=="april"){
		return 4;
	}
	else if(mn=="May"||mn=="may"){
		return 5;
	}
	else if(mn=="June"||mn=="june"){
		return 6;
	}
	else if(mn=="July"||mn=="july"){
		return 7;
	}
	else if(mn=="August"||mn=="august"){
		return 8;
	}
	else if(mn=="September"||mn=="september"){
		return 9;
	}
	else if(mn=="October"||mn=="october"){
		return 10;
	}
	else if(mn=="November"||mn=="november"){
		return 11;
	}
	else if (mn=="December"||mn=="december"){
		return 12;
	}
	else{
		return 0;
	}
}

//no more change
Date getDate();

int main() {

   Date testDate;
   testDate = getDate();
   cout << endl;
   cout << "Numeric: ";
   testDate.printNumeric();
   cout << endl;
   cout << "Alpha:   ";
   testDate.printAlpha();
   cout << endl;

   return 0;
}

Date getDate() {
   int choice;
   unsigned monthNumber, day, year;
   string monthName;

   cout << "Which Date constructor? (Enter 1, 2, or 3)" << endl
      << "1 - Month Number" << endl
      << "2 - Month Name" << endl
      << "3 - default" << endl;
   cin >> choice;
   cout << endl;

   if (choice == 1) {
      cout << "month number? ";
      cin >> monthNumber;
      cout << endl;
      cout << "day? ";
      cin >> day;
      cout << endl;
      cout << "year? ";
      cin >> year;
      cout << endl;
      return Date(monthNumber, day, year);
   } else if (choice == 2) {
      cout << "month name? ";
      cin >> monthName;
      cout << endl;
      cout << "day? ";
      cin >> day;
      cout << endl;
      cout << "year? ";
      cin >> year;
      cout << endl;
      return Date(monthName, day, year);
   } else {
      return Date();
   }
}
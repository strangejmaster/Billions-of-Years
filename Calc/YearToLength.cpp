#include <iostream>

using namespace std;

//+X = position farther right
//-X = position farther left


/*Create main definitions*/
#define StartingYear 21000.00 //This will evenly divide into an amount of units

#define ScreenSize 800 //This is the width of the screen object in Unity
#define lowYear 500000


/*Define declare and initialize variables*/
int Width = 50; //Width of event object
int leftNum, rightNum = 0; //leftNum: The number if the event object has the Line drawn down onto the timeline on the leftmost side
                            //rightNum: The number if the event object has the Line drawn down onto the timeline on the rightmost side
char confirmation = 'e'; //Char to store user input validating whether or not their input year was correct




//This turns a number into a string with commas every 3 numbers for readablity that can be outputed to check if the user has inputed the correct value
template<class T>
std::string FormatWithCommas(T value) {
    auto s = std::to_string(value);

   int n = s.length() - 3;
   int end = (value >= 0) ? 0 : 1; // Support for negative numbers
   while (n > end) {
      s.insert(n, ",");
      n -= 3;
   }
   return s;
}
void calc();

int main() {calc(); return 0;}

void calc() {
    unsigned long long int year;
    //Get user input: Getting the year they want to convert into an X-position
    cout << "Enter how many years ago event was: " << endl;
    cin >> year;

    //Validate user input since they may make a mistake entering large numbers
    cout << FormatWithCommas(year) << endl; //Add commas every 3 numbers of the input for clarity and output it
    cout << "Confirm?: (y/n)" << endl;
    cin >> confirmation; //Get confirmation
    if (confirmation == 'n') { /*delete year;*/ calc(); } //Recalls the function if number is incorrect so user can reenter year

    //Decide size of variable to use
    //Cast unsigned long long int to float if the memory permits
    /*if (*year <= lowYear) {
        //Stores a temporary pointer with value while we delete the first pointer to avoid error
        float* temp = (float*)*year;
        delete year;
        float* year;
        year = temp;
        delete temp;
    }*/

    //Calculate correct ratio of screen size to starting year if it is defined
    float ConversionFactor = StartingYear/ScreenSize;
    
    float distance = year/ConversionFactor; //Units away from 0 years ago on timeline
    float finalNum = distance; //finalNum will be the number that has operations done to it to correctly place it on the timeline, it will not necessarily be the number outputed
    finalNum = 400-distance; //This shifts the center point from the middle to the right side since in Unity the scene has a center point at 0,0 with the leftmost point being -400,0 and the rightmost point being 400,0 but the timeline number must be units away from the right side so we shift the center to the right side.

    //Since the position is set to the center of the object and the line of the box is set on to the edge of one of the sides we must offset the object to make sure the line on the edge lines up with the final position
    //We do this by adding or subtracting half the width of the box which moves the center over by half and offsetting the line on the Timeline to the center and correct position
    leftNum = finalNum+Width/2;
    rightNum = finalNum-Width/2;

    //Output Final Values
    cout << "Left Bound Number: " << leftNum << endl;
    cout << "Right Bound Number: " << rightNum << endl;

    //Output Debugging Values
    cout << "\n\tDEBUGGING VALUES:" << endl;
    cout << "\t\tCalculated Number: " << finalNum << endl;
    cout << "\t\tDistance (year/ConversionFactor): " << distance << endl;
    cout << "\t\tConversion Factor: " << ConversionFactor << endl;
    cout << "\t\tStarting Value: " << StartingYear << endl;

    //Cleanup leftover pointers
    //delete year;

    calc(); //Recursively run code so the user can input multiple dates
}
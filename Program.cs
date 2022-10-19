//Savannah Rimmele
//MasterMind 10.18.2022
//Description: Implement a program that randomly generates a secret 4-digit code, where each digit is between 1-6. 
//The user has 12 attempts to guess the secret code. After each guess, a score is printed where + represents
//a digit in the correct position of the user's guess, while a - shows an incorrect digit or position. 
//All +'s are printed first. 

using System; 

namespace Mastermind
{
    class Program
    {
        private static Random digit = new Random(); 
        private static string code = ""; 

        //Generate a random digit between 1-6 at each position of a string 
        //to retrieve a random 4-digit code. 
        public static string codeGeneration(){

            for(int i = 0; i < 4; ++i){   
                code = code.Insert(i, digit.Next(1,7).ToString()); 
            }

            return code;  
        }

        //Accept a user input from the Command Line. 
        //Check if the input is of length 4 and only contains numbers 1-6. 
        //Otherwise, print a message until the requirements are satisfied.
        public static string userInput(){
            Console.Write("Please enter your 4-digit guess: "); 
            string? userGuess = Console.ReadLine();  
            while(userGuess?.Length != 4 || userGuess == null || userGuess.Any(d => !char.IsNumber(d)) || userGuess.Any(d => d == '0') || userGuess.Any(d => d > '6')){
                Console.WriteLine("Sorry! Please ensure your input satisfies the following requirements:  "); 
                Console.WriteLine(" -Code must be 4-digits in length. \n -Each digit must be between 1 and 6. \n -Code cannot contain letters or symbols."); 
                userGuess = Console.ReadLine(); 
            }

            return userGuess; 
        }

        //Compare the user's guess to the generated code. 
        //Count the number of correct digits/positions to print +
        //Otherwise, print -
        public static void plusOrMinus(string userInput, string code){
            int numCorrect = 0; 
            //Iterate the user's guess to determine if the guessed digit matches the digit of the secret code at position i. 
            //Increment the count of numCorrect for each iteration that holds true. 
            for(int i = 0; i < 4; i++){
                if(userInput[i] == code[i]){
                    numCorrect++; 
                }
            }

            //For the length of the secret code, use numCorrect to determine how many +'s to print
            //Otherwise, print -'s
            for(int j = 0; j < 4; j++){
                if(j < numCorrect){
                   Console.Write("+"); 
                }
                else{
                    Console.Write("-"); 
                }
            }
            Console.WriteLine(); 
        }


        //Allow the user 12 attempts to break the secret code
        //Use the plusOrMinus function to print the user's score
        //Print the specified response, depending on if the user wins or loses. 
        public static void winOrLose(string codeValue){
            string attempt = ""; 
            //Show attempt number and prompt the user for their guess. 
            for(int i = 1; i < 13; i++){
                Console.WriteLine("Attempt #" + i); 
                attempt = userInput(); 
                Console.Write("Your guess:" + attempt +"\n"); 
                plusOrMinus(attempt, codeValue); 
                Console.WriteLine(); 

                if(attempt == codeValue){
                    Console.WriteLine("You solved it!"); 
                    break; 
                }
            } 

            if(attempt != codeValue){
                Console.WriteLine("You lose :(");
            }
        }

        //Driver Code
        static void Main()
        {
            string codeValue = codeGeneration(); 
            winOrLose(codeValue); 
        }
    }
}
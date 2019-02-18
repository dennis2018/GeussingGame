using System;

namespace GuessingGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Welcome users
            Console.WriteLine("Welcome to inputGuess Game!");

			// Generate random number and assign it to a variable.
			int randomNumber = new Random().Next(1, 101);

            // Count each inputGuess and stop if attemtps reach to 7.
            int inputGuess;
            int countInputGuess = 0;
            Boolean userWin = false;

            // Play game function. calls validateInput and evaluateAnswer methods.
            void playGame()
            {
                while (countInputGuess != 7 && userWin != true)
                {
					// Ask user for input
					Console.WriteLine("\nPlease enter your guess between 1 and 100!");

					// Increase by one each time student attempt an answer
					countInputGuess++;

                    var userInput = Console.ReadLine();

                    if (validateInput(userInput))
                    {
                        Console.WriteLine(evaluateAnswer());
                    }
                    else
                    {
                        Console.WriteLine("Not a valid number! You also lost an attempt.");
                    }
                }
            }

            playGame();

			// Validate number function and returns number
			Boolean validateInput(String userInput)
			{

				if (int.TryParse(userInput, out inputGuess))
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			// Evaluate answer function to determine WIN or LOST
			String evaluateAnswer()
			{
				if (inputGuess == randomNumber)
				{
					userWin = true;
					return $"YOU WIN. The number is { randomNumber } and your inputGuess is { inputGuess } :) \n";
				}
				else if (countInputGuess == 7)
				{
					return $"\nYou Lost! You have tried { countInputGuess } times with no luck :( Random Number is { randomNumber } \n";
				}
				else
				{
					if (inputGuess < randomNumber)
					{
						return $"Guess is too low! You have attempted { countInputGuess } times. \n";
					}
					else
					{
						return $"Guess is too high! You have attempted { countInputGuess } times. \n";
					}
				}
			}

            // Reset game function to start again or quite game
            Boolean resetGame(){
				Console.WriteLine("\nDo you want to play again? Y for yes");
				userWin = false;
                countInputGuess = 0;

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    return true;
                }
                else return false;
            }

            // Keep playing if user is interested.
            while(resetGame()) {
				playGame();
				resetGame();
			}
		}
    }
}

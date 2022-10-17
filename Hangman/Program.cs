using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.Linq;

namespace Hangman
{
    internal class Program
    {
        // giving our function a type before it's run, this is void
        private static void hangmanGame(int wrong)
        {
            if(wrong == 0)
            {
                // draw the stick body with no limbs if wrong is 0
                Console.WriteLine("\n+---+");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("  ===");
            }
            else if(wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("  ===");
            }
            else if(wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine(" |  |");
                Console.WriteLine("   |");
                Console.WriteLine("  ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine(" |  |");
                Console.WriteLine("/   |");
                Console.WriteLine("  ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine(" |  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("  ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("  ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("  ===");
            }
            
        }
        // the type of this function returns an integer(int)
        // first parameter is a list that contains characters named guessedLetters
        // second parameter is a String named randomWord, whatever word is selected randomly
        private static int printWord(List<char>guessedLetters, String randomWord)
        {
            // counter to iterate through the random word
            int counter = 0;
            // letters that the user has guessed correctly
            int correctLetters = 0;
            Console.Write("\r\n");
            foreach (char c in guessedLetters)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    correctLetters++;

                }
                else
                {
                    Console.Write(" ");

                }
                counter++;
            }
            return correctLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach(char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                // printing an upperscore character with the Unicode language
                Console.Write("\u0305 ");

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman!");
            Console.WriteLine("-------------------------");
            Random random = new Random();
            List<String> wordDictionary = new List<String> { "glyph", "gangster", "ponytail", "weirdo", "mississippi", "baseball", "florida", "phenomenon", "yellowstone", "smashing" };
            // creating index integer to pick a random word from the amount of words given
            int index = random.Next(wordDictionary.Count);
            // creating our random word by taking the word at the random "index" that we just created
            String randomWord = wordDictionary[index];
            // loop through the letters in the word to create a dash for each letter
            foreach(char c in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordGuess = randomWord.Length;
            int wrongGuesses = 0; 
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (wrongGuesses != 6 && currentLettersRight != lengthOfWordGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach(char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " "); 

                }
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\nYou have already guessed this letter.");
                    // our hangmanGame function takes in an integer so we pass it the wrongGuesses variable
                    // if you don't pass anything in you get an error message that says it doesn't correspond, kinda nice
                    hangmanGame(wrongGuesses);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    // loop through the random word and if the letter guessed matches any letters at position i then the user is correct
                    for(int i = 0; i < randomWord.Length; i++) { if(letterGuessed == randomWord[i]) { right = true; } }
                    if (right)
                    {
                        hangmanGame(wrongGuesses);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        //Console.WriteLine("Correct!");
                        Console.WriteLine("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        wrongGuesses++;
                        currentLettersGuessed.Add(letterGuessed);
                        hangmanGame(wrongGuesses);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        //Console.WriteLine("Wrong!");
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame is over!");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWordle2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] animals = { "duck", "goat", "bear", "lion", "frog", "deer", "swan", "wolf", "crab" };
            char[] allowedCharacters = 
            { 
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' 
            };
            const int NumberOfGuesses = 6;
            const int NumberOfLetters = 4;
            string name;
            char[] solution = animals[rand.Next(animals.Length)].ToCharArray();
            Console.WriteLine("Welcome to Animal Wordle!");
            Console.WriteLine("Wordle is a word game that was created and developed by Welsh software engineer\r\nJosh Wardle. In the original version of Wordle, players have six attempts to guess\r\na five-letter word, with feedback given for each guess in the form of coloured\r\ntiles indicating when letters match or occupy the correct position.");
            Console.WriteLine("In Animal Wordle, players have six attempts to guess a four-letter animal, with\r\nfeedback given for each guess indicating when letters match or occupy the correct\r\nposition. If the character is in the correct position, it is indicated with a hash\r\n(#). If a character is correct, but in the wrong position, it is indicated with a\r\nhyphen (-). If a character is incorrect, it is represented with a full stop (.).");
            Console.Write("Please enter your name: ");
            while (true)
            {
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }
                Console.Write("Name cannot be blank, please re input: ");
            }
            Console.Write($"Hi {name}! Would you like to play Wordle? [y/n]: ");
            while (true)
            {
                char answer = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (answer == 'y' || answer == 'Y')
                {
                    break;
                }
                if (answer == 'n' || answer == 'N')
                {
                    return;
                }
                Console.Write("Your answer must be \"y\" or \"n\": ");
            }
            for (int guessesLeft = NumberOfGuesses; guessesLeft > 0; guessesLeft--)
            {
                string feedback = "";
                char[] lettersGuessed = new char[4];
                Console.WriteLine($"You have {guessesLeft} guesses left.");
                Console.WriteLine("Please enter your four-letter guess:");
                for (int letterNumber = 1; letterNumber <= NumberOfLetters; letterNumber++)
                {
                    while (true)
                    {
                        Console.Write($"Letter {letterNumber}: ");
                        char letter = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (allowedCharacters.Contains(letter))
                        {
                            if (solution[letterNumber - 1] == letter)
                            {
                                feedback += "#";
                            }
                            else if (solution.Contains(letter))
                            {
                                feedback += "-";
                            }
                            else
                            {
                                feedback += ".";
                            }
                            lettersGuessed[letterNumber - 1] = letter;
                            break;
                        }
                        Console.WriteLine("The letter input must be a letter from a-z.");
                    }
                }
                Console.WriteLine($"Result = {feedback}");
                if (feedback == "####")
                {
                    Console.WriteLine("Woohoo! You guessed the word correctly!");
                    break;
                }
                else if (feedback.ToCharArray().Contains('#') || feedback.ToCharArray().Contains('-'))
                {
                    Console.WriteLine("Getting there! Keep guessing!");
                }
                else
                {
                    Console.WriteLine("Whoops, no letters are correct! Keep guessing!");
                }
            }
        }
    }
}
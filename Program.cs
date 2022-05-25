using System;
using System.Threading;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] messages = {@" __    __       ___      .__   __.   _______ .___  ___.      ___      .__   __.
|  |  |  |     /   \     |  \ |  |  /  _____||   \/   |     /   \     |  \ |  |
|  |__|  |    /  ^  \    |   \|  | |  |  __  |  \  /  |    /  ^  \    |   \|  |
|   __   |   /  /_\  \   |  . `  | |  | |_ | |  |\/|  |   /  /_\  \   |  . `  |
|  |  |  |  /  _____  \  |  |\   | |  |__| | |  |  |  |  /  _____  \  |  |\   |
|__|  |__| /__/     \__\ |__| \__|  \______| |__|  |__| /__/     \__\ |__| \__|", @"____    ____  ______    __    __     ____    __    ____  __  .__   __.  __ 
\   \  /   / /  __  \  |  |  |  |    \   \  /  \  /   / |  | |  \ |  | |  |
 \   \/   / |  |  |  | |  |  |  |     \   \/    \/   /  |  | |   \|  | |  |
  \_    _/  |  |  |  | |  |  |  |      \            /   |  | |  . `  | |  |
    |  |    |  `--'  | |  `--'  |       \    /\    /    |  | |  |\   | |__|
    |__|     \______/   \______/         \__/  \__/     |__| |__| \__| (__)", @"____    ____  ______    __    __      __        ______        _______. _______  __ 
\   \  /   / /  __  \  |  |  |  |    |  |      /  __  \      /       ||   ____||  |
 \   \/   / |  |  |  | |  |  |  |    |  |     |  |  |  |    |   (----`|  |__   |  |
  \_    _/  |  |  |  | |  |  |  |    |  |     |  |  |  |     \   \    |   __|  |  |
    |  |    |  `--'  | |  `--'  |    |  `----.|  `--'  | .----)   |   |  |____ |__|
    |__|     \______/   \______/     |_______| \______/  |_______/    |_______|(__)"};
            string[] counter = { @" _____ 
| ____|
| |__
|___ \ 
 ___) |
| ____ / ", @" _  _   
| || |
| || |_
|__   _|
   | |
   |_|", @" ____  
|___ \ 
  __) |
 |__ < 
 ___) |
|____/ ", @" ___  
|__ \ 
   ) |
  / / 
 / /_ 
|____|", @" __ 
/_ |
 | |
 | |
 | |
 |_|" };

            string startWord = "BRENDEN";
            string maskStartWord = new string('-', startWord.Length);
            string guessedCharacter = "";
            string guessedCharacterList = "";

            bool gameOver = false;

            int guessTries = startWord.Length * 2;

            Console.CursorVisible = false;
            //Welcome Message
            Console.WriteLine(messages[0]);

            //Countdown for game
            foreach (string item in counter)
            {
                Console.Clear();
                Console.WriteLine(messages[0]);
                Console.WriteLine(item);
                Thread.Sleep(1000);
            }

            //Game Logic
            while (!gameOver)
            {
                Console.Clear();
                Console.WriteLine("Guess the word: {0}", maskStartWord);
                Console.WriteLine("Guessed Characters: {0}", guessedCharacterList);
                Console.WriteLine("You have {0} guesses left.", guessTries);
                Console.WriteLine();
                Console.Write("Your next guess is: ");    
                guessedCharacter = Console.ReadLine().ToUpper();
                guessedCharacterList += guessedCharacter + " ";

                if (startWord.Contains(guessedCharacter))
                {
                    for (int i = 0; i <= startWord.Length - 1; i++)
                    {
                        string currentCharacter = startWord[i].ToString();
                        if (currentCharacter == guessedCharacter)
                        {
                            char[] maskedArray = maskStartWord.ToCharArray();
                            maskedArray[i] = Convert.ToChar(guessedCharacter);
                            maskStartWord = new string(maskedArray);
                        }
                    }
                    if (startWord == maskStartWord)
                    {
                        Console.Clear();
                        Console.WriteLine(messages[1]);
                        Console.WriteLine("Congratulations, you guessed the word: {0}!", startWord);
                        gameOver = true;
                    }
                }
                else
                {
                    guessTries--;
                }

                if (guessTries == 0)
                {
                    gameOver = true;
                    Console.WriteLine(messages[2]);
                    Console.WriteLine("The word was {0)", startWord);
                }
            }
        }
    }
}

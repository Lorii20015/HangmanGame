using System;
using System.Collections.Generic;
using System.IO;

namespace Šibenica
{
    class Program
    {
        public static List<string> listWords = new List<string>();
        public static string hiddenWord;
        public static string guess;
        public static List<char> displayedWordList = new List<char>();
        public static List<char> guessesList = new List<char>();
        public static string[] moreWordsArray;
        public static List<string> moreWordsList = new List<string>();
        public static int end;
        static void Main(string[] args)
        {
            Console.WriteLine("Are you playing alone?(yes/no)");
            string playerNum = Console.ReadLine().ToLower();
            while (end == 0)
            {
                if (playerNum == "yes")
                {
                    StreamReader RandomWords = new StreamReader("../../../RandomWords.txt");
                    string line;
                    while ((line = RandomWords.ReadLine()) != null)
                    {
                        listWords.Add(line);
                        Random rand = new Random();
                        int number = rand.Next(0, listWords.Count);
                        hiddenWord = listWords[number];
                    }
                    if (hiddenWord.Contains(' ') == true)
                    {
                        guessesList.Add(' ');
                    }
                    if (hiddenWord.Contains(',') == true)
                    {
                        guessesList.Add(',');
                    }
                    if (hiddenWord.Contains('.') == true)
                    {
                        guessesList.Add('.');
                    }
                    int letters = hiddenWord.Length;
                    for (int i = 0; i < letters; i++)
                    {
                        Console.Write("_");
                    }
                    Console.Write("\n");
                    while (guess != hiddenWord)
                    {
                        Console.Write("Enter the letter or word you'd like to try:");
                        guess = Console.ReadLine().ToLower();
                        if (hiddenWord.Contains(guess) == true)
                        {
                            bool CanBeChar = char.TryParse(guess, out char charGuess);
                            if (CanBeChar == true)
                            {
                                guessesList.Add(charGuess);
                                List<char> listOfCharacters = new List<char>();
                                foreach (char element in hiddenWord)
                                {
                                    listOfCharacters.Add(element);
                                    if (guessesList.Contains(element))
                                    {
                                        displayedWordList.Add(element);
                                    }
                                    else
                                    {
                                        displayedWordList.Add('_');
                                    }
                                }
                                for (int i = 0; i < displayedWordList.Count; i++)
                                {
                                    Console.Write(displayedWordList[i]);
                                }
                                Console.Write("\n");
                                if (displayedWordList.Contains('_') == false)
                                {
                                    Console.WriteLine("Congratulations! You've guessed the word and won the game! :D");
                                    end = 1;
                                }
                                displayedWordList.Clear();
                             //   Console.WriteLine(hiddenWord);
                            }
                            else if (hiddenWord == null)
                            {
                                Console.WriteLine("Please, don't hit enter without typing anything!");
                            }
                            else if (hiddenWord.Contains(guess) == true && guess != hiddenWord)
                            {
                                Console.WriteLine("It is part of the word! (It won't show it as guessed part of the word, sorry!)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nope, try some other letter or word! :)");
                        }
                    }
                        Console.WriteLine("Congratulations! You've guessed the word and won the game! :D");
                        end = 1;
                }
                else if (playerNum == "no")
                {
                    Console.Write("Hello!\n Enter the word(/s) you'd like to have the other person guess:");
                    hiddenWord = Console.ReadLine().ToLower();
                    Console.WriteLine("Tap enter one more time!");
                    Console.Clear();
                    if (hiddenWord.Contains(' ') == true)
                    {
                        guessesList.Add(' ');
                    }
                    if (hiddenWord.Contains(',') == true)
                    {
                        guessesList.Add(',');
                    }
                    if (hiddenWord.Contains('.') == true)
                    {
                        guessesList.Add('.');
                    }
                    int letters = hiddenWord.Length;
                    for (int i = 0; i < letters; i++)
                    {
                        Console.Write("_");
                    }
                    Console.Write("\n");
                    while (guess != hiddenWord)
                    {
                        Console.Write("Enter the letter or word/s you'd like to try:");
                        guess = Console.ReadLine().ToLower();
                        if (hiddenWord.Contains(guess) == true)
                        {
                            bool CanBeChar = char.TryParse(guess, out char charGuess);
                            if (CanBeChar == true)
                            {
                                guessesList.Add(charGuess);
                                List<char> listOfCharacters = new List<char>();
                                foreach (char element in hiddenWord)
                                {
                                    listOfCharacters.Add(element);
                                    if (guessesList.Contains(element))
                                    {
                                        displayedWordList.Add(element);
                                    }
                                    else
                                    {
                                        displayedWordList.Add('_');
                                    }
                                }
                                for (int i = 0; i < displayedWordList.Count; i++)
                                {
                                    Console.Write(displayedWordList[i]);
                                }
                                Console.Write("\n");
                                if (displayedWordList.Contains('_') == false)
                                {
                                    Console.WriteLine("Congratulations! You've guessed the word and won the game! :D");
                                    end = 1;
                                }
                                displayedWordList.Clear();
                                //   Console.WriteLine(hiddenWord);
                            }
                            else if (hiddenWord == null)
                            {
                                Console.WriteLine("Please, don't hit enter without typing anything!");
                            }
                            else if (hiddenWord.Contains(guess) == true && guess != hiddenWord)
                            {
                                Console.WriteLine("It is part of the word or phrase! (It won't show it as guessed part of the word, sorry!)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nope, try some other letter or word! :)");
                        }
                    }
                    Console.WriteLine("Congratulations! You've guessed the word and won the game! :D");
                    end = 1;
                }
                else
                {
                    Console.WriteLine("Please, only write yes or no!");
                    break;
                }
            }
        }
    }   
}

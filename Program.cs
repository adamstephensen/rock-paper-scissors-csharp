// write a rock, paper, scissors game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RockPaperScissors
{
    enum RPSChoice
    {
        Rock,
        Paper,
        Scissors
    }

    interface IPlayer
    {
        string name { get; set; }
        RPSChoice choice { get; set; }
        void GetChoice();
    }
    class Human : IPlayer
    {
        public string name { get; set; }
        public RPSChoice choice { get; set; }
        public void GetChoice()
        {
            UI.DisplayChoices();
            while (true)
            {
                string input = UI.GetUserInput("");
                if (Enum.TryParse<RPSChoice>(input, out RPSChoice result))
                {
                    choice = result;
                    break;
                }
                UI.DisplayInvalidChoice();
            }
        }
    }
    class Computer : IPlayer
    {
        public string name { get; set; }
        public RPSChoice choice { get; set; }
        public void GetChoice()
        {
            Random rnd = new Random();
            choice = (RPSChoice)rnd.Next(0, 3);
        }
    }
    class UI
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static void DisplayChoices()
        {
            Console.WriteLine("Enter your choice (Rock, Paper, or Scissors): ");
        }

        public static void DisplayInvalidChoice()
        {
            Console.WriteLine("Invalid choice. Please enter Rock, Paper, or Scissors.");
        }
    }

    class Game
    {
        public IPlayer player1 { get; set; }
        public IPlayer player2 { get; set; }
        public void Start()
        {
            UI.DisplayChoices();
            player1.GetChoice();
            player2.GetChoice();
            UI.DisplayMessage("Player 1 chose: " + player1.choice);
            UI.DisplayMessage("Player 2 chose: " + player2.choice);
            if (player1.choice == player2.choice)
            {
                UI.DisplayMessage("It's a tie!");
            }
            else if (player1.choice == RPSChoice.Rock && player2.choice == RPSChoice.Scissors)
            {
                UI.DisplayMessage("Player 1 wins!");
            }
            else if (player1.choice == RPSChoice.Paper && player2.choice == RPSChoice.Rock)
            {
                UI.DisplayMessage("Player 1 wins!");
            }
            else if (player1.choice == RPSChoice.Scissors && player2.choice == RPSChoice.Paper)
            {
                UI.DisplayMessage("Player 1 wins!");
            }
            else
            {
                UI.DisplayMessage("Player 2 wins!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.player1 = new Human();
            game.player2 = new Computer();
            game.Start();
        }
    }
}

// write a rock, paper, scissors game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xunit;


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
        string Name { get; set; }
        RPSChoice Choice { get; set; }
        int Score { get; set; }

    }
    class HumanPlayer : IPlayer
    {
        public string Name { get; set; }
        public RPSChoice Choice { get; set; }
        public int Score { get; set; }
    }
    class ComputerPlayer : IPlayer
    {
        public string Name { get; set; }
        public RPSChoice Choice { get; set; }
        public int Score { get; set; }
    }

    class RPSCalculator
    {
        public static RPSChoice? GetWinner(RPSChoice choice1, RPSChoice choice2)
        {
            if (choice1 == choice2)
            {
                return null;
            }
            else if (choice1 == RPSChoice.Rock && choice2 == RPSChoice.Scissors)
            {
                return choice1;
            }
            else if (choice1 == RPSChoice.Paper && choice2 == RPSChoice.Rock)
            {
                return choice1;
            }
            else if (choice1 == RPSChoice.Scissors && choice2 == RPSChoice.Paper)
            {
                return choice1;
            }
            else
            {
                return choice2;
            }
        }
    }


public class Program{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Rock Paper Scissors!");
        Console.WriteLine("Please enter your name: ");
        var name = Console.ReadLine();
        var humanPlayer = new HumanPlayer { Name = name };
        var computerPlayer = new ComputerPlayer { Name = "Computer" };
        var players = new List<IPlayer> { humanPlayer, computerPlayer };

        while (true)
        {
            Console.WriteLine("Please choose Rock, Paper, or Scissors");
            var input = Console.ReadLine();
            var humanChoice = GetHumanChoice(input);
            if (humanChoice == null)
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            humanPlayer.Choice = humanChoice.Value;
            var computerChoice = GetComputerChoice();
            computerPlayer.Choice = computerChoice;
            var winner = RPSCalculator.GetWinner(humanChoice.Value, computerChoice);
            if (winner == null)
            {
                Console.WriteLine("It's a tie!");
            }
            else if (winner == humanChoice)
            {
                Console.WriteLine($"{humanPlayer.Name} wins!");
                humanPlayer.Score++;
            }
            else
            {
                Console.WriteLine($"{computerPlayer.Name} wins!");
                computerPlayer.Score++;
            }
            Console.WriteLine($"{humanPlayer.Name}: {humanPlayer.Score}");
            Console.WriteLine($"{computerPlayer.Name}: {computerPlayer.Score}");
            Console.WriteLine("Play again? (Y/N)");
            var playAgain = Console.ReadLine();
            if (playAgain.ToUpper() != "Y")
            {
                break;
            }
        }
    }
    static RPSChoice? GetHumanChoice(string input)
    {
        input = input.ToLower();
        if (input == "rock")
        {
            return RPSChoice.Rock;
        }
        else if (input == "paper")
        {
            return RPSChoice.Paper;
        }
        else if (input == "scissors")
        {
            return RPSChoice.Scissors;
        }
        else
        {
            return null;
        }
    }
    static RPSChoice GetComputerChoice()
    {
        var values = Enum.GetValues(typeof(RPSChoice));
        var random = new Random();
        var randomChoice = (RPSChoice)values.GetValue(random.Next(values.Length));
        return randomChoice;
    }
}




}

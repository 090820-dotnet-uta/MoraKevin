using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS_Game_Refactored
{
    public static class RpsGameMethods
    {
        /// <summary>
        /// returns a new game initialized with the players in the game
        /// </summary>
        /// <returns> game </returns>
        public static Game NewGameBetween(Player p1, Player computer){
            Game game = new Game();// create a game
            game.Player1 = p1;//
            game.Computer = computer;//
            return game;
        }

        /// <summary>
        /// Get a choice of 1 (play) or 2 (quit) from the user
        /// </summary>
        /// <returns>
        /// integer
        /// </returns>
        public static int GetUsersIntent()
        {
            int choice;//this is be out variable choice of the player to 1 (play) or 2 (quit)
            bool inputInt;
            do//prompt loop
            {
                System.Console.WriteLine("Please choose 1 for Play or 2 for Quit");
                string input = Console.ReadLine();
                inputInt = int.TryParse(input, out choice);
            } while (!inputInt || choice <= 0 || choice >= 3);//end of promt loop

            return choice;
        }

        /// <summary>
        /// This method takes 3 lists and prints out the contents of all of them.
        /// </summary>
        /// <param name="games"></param>
        /// <param name="players"></param>
        /// <param name="rounds"></param>
        public static void PrintAllCurrentData(List<Game> games, List<Player> players, List<Round> rounds)
        {
            foreach (var game in games)
            {
                System.Console.WriteLine($"Player1 Name => {game.Player1.Name}\ncomputer Name => {game.Computer.Name}\n winner is => {game.winner.Name}");
                System.Console.WriteLine($"\n\t--- Here are the details of each games rounds --- ");
                foreach (Round round in game.rounds)
                {
                    System.Console.WriteLine($"player1 => {round.player1.Name}, p1 choice => {round.p1Choice}");
                    System.Console.WriteLine($"player2 => {round.Computer.Name}, computer choice => {round.ComputerChoice}");
                    System.Console.WriteLine($"The Outcome (Winner) of this round is player {round.Outcome}\n");
                    if (round.Outcome == 1)
                    {
                        System.Console.WriteLine($"WINNER => {game.Player1.Name}\n");
                    }
                    else if (round.Outcome == 2)
                    {
                        System.Console.WriteLine($"WINNER => {game.Computer.Name}\n");
                    }
                }
            }

            System.Console.WriteLine("Here is the list of players.");
            foreach (var player in players)
            {
                System.Console.WriteLine($"This players name is {player.Name} and he has {player.record["wins"]} wins and {player.record["losses"]} losses");
            }
        }

        /// <summary>
        /// Gets the players name from the user and returns a string
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerName()
        {
            System.Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            playerName.Trim();//take off beginning or ending white space
            return playerName;
        }

        /// <summary>
        /// checks the list of players to see if the player is returning. If not, creates a new player and adds him to the List<Player>
        /// </summary>
        /// <returns></returns>
        public static Player VerifyPlayer(List<Player> players, string playerName)
        {
            Player p1 = new Player();

            // check the list of players to see if this player is a returning player.
            foreach (Player item in players)
            {
                if (item.Name == playerName)
                {
                    p1 = item;
                    System.Console.WriteLine("You are a returning player. Game ON!");
                    break;//end the foreach loop
                }
            }

            if (p1.Name == "null")//means the players name was not found above
            {
                p1.Name = playerName;
                players.Add(p1);
            }
            return p1;
        }

        /// <summary>
        /// Allows player one to make a choice between paper rock or scissors
        /// </summary>
        /// <returns> Choice </returns>
        public static Choice GetPlayer1Choice(){
            string input;
            int p1choice;
            bool isNum;
            do
            {
                System.Console.WriteLine("\nPlease pick Rock(0), Paper(1), or Scissors(3) - enter a number");
                input = System.Console.ReadLine();
                isNum = int.TryParse(input, out p1choice);
                if (!isNum || p1choice < 0 || p1choice > 3)
                {
                    System.Console.WriteLine("\nYou must select enter either 0, 1, or 2.\n");
                }
            }
            while (!isNum || p1choice < 0 || p1choice > 3);

            return (Choice)p1choice;
        }

        /// <summary>
        /// Returns a random Choice of Rock,Paper, Scissors
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Choice GetRandomChoice()
        {
            Random rand = new Random();
            return (Choice)rand.Next(3);
        }

        public static void GetRoundWinner(Round round)
        {
            if (round.p1Choice == round.ComputerChoice)
            {
                round.Outcome = 0; // it’s a tie . the default is 0 so this line is unnecessary.
                System.Console.WriteLine("this round was a tie");
            }
            else if ((int)round.p1Choice == ((int)round.ComputerChoice + 1) % 3)
            { //If users pick is one more than the computer’s, user wins
                round.Outcome = 1;
            }
            else
            { //If it’s not a tie and p1 didn’t win, then computer wins.
                round.Outcome = 2;
            }
        }

        /// <summary>
        /// determines if either player has won 2 rounds yet.
        /// </summary>
        /// <param name="game"></param>
        /// <returns>int</returns>
        public static int GetWinner(Game game)
        {
            // get how many rounds p1 has won.
            if (game.rounds.Count(x => x.Outcome == 1) == 2) { return 1; }
            else if (game.rounds.Count(x => x.Outcome == 2) == 2) { return 2; }// get how many rounds computer has won.
            else return 0;
        }

        /// <summary>
        /// increments the number of wins for the winner and prints a statement stating who won
        /// <summary>
        /// <returns> void </returns>
        public static void IncrementWinnerAndPrint(int whoWon, Game game, Player p1, Player computer){
            if (whoWon == 1)
            {
                game.winner = p1;
                p1.record["wins"]++;//increments wins and losses.
                computer.record["losses"]++;//increments wins and losses.
                System.Console.WriteLine($"The winner of this game was Player1\n");
            }
            else if (whoWon == 2)
            {
                game.winner = computer;
                p1.record["losses"]++;//increments wins and losses.
                computer.record["wins"]++;//increments wins and losses.
                System.Console.WriteLine($"The winner of this game was the computer\n");
            }
        }
    }
}
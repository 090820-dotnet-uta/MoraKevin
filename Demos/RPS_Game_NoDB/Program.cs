using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS_Game_NoDB
{
    public enum Choice
    {
        Rock,//can be accessed with a 0
        Paper,//can be accessed with a 1
        Scissors//can be accessed with a 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Game> games = new List<Game>();
            List<Round> rounds = new List<Round>();
            int choice;
            Player computer = new Player() { Name = "Computer" };//instantiate a Player and give a value to the Name all at once.
            players.Add(computer);
            int gameCounter = 1;

            do//game loop
            {
                //get a choice from the user (play or quit)
                bool inputInt;
                do//prompt loop
                {
                    System.Console.WriteLine("\nPlease choose 1 for Play or 2 for Quit");
                    string input = Console.ReadLine();
                    inputInt = int.TryParse(input, out choice);
                    System.Console.WriteLine($"\n\tThis is game #{gameCounter++}\n");
                } while (!inputInt || choice <= 0 || choice >= 3);//end of promt loop

                if (choice == 2)//if the user chose 2, break out of the game.
                {
                    break;
                }
                //System.Console.WriteLine("made it out of the loop");

                //get the player name
                System.Console.WriteLine("\nWhat is your name?");
                string playerName = Console.ReadLine();
                Player p1 = new Player();//p1 is null here.

                // check the list of players to see if this payer is a returning player.
                foreach (Player item in players)
                {
                    if (item.Name == playerName)
                    {
                        p1 = item;
                        System.Console.WriteLine("\nYou are a returning player");
                        break;//end the foreach loop
                    }
                }

                if (p1.Name == "null")//means the players name was not found above
                {
                    p1.Name = playerName;
                    players.Add(p1);
                }

                Game game = new Game();// create a game
                game.Player1 = p1;//
                game.Computer = computer;//

                Random rand = new Random();

                //play rounds till one player has 2 wins
                //assign the winner to the game and check that property to break out of the loop.
                while (game.winner.Name == "null")
                {
                    Round round = new Round();//declare a round for this iteration
                    round.game = game;// add the game to this round
                    round.player1 = p1;// add user (p1) to this round
                    round.Computer = computer;// add computer to this round

                    //get the choices for the 2 players
                    string input;
                    int p1choice;
                    bool isNum;
                    do 
                    {
                        System.Console.WriteLine("\nPlease pick Rock(0), Paper(1), or Scissors(3) - enter a number");
                        input = System.Console.ReadLine();
                        isNum = int.TryParse(input, out p1choice);
                        if (!isNum || p1choice < 0 || p1choice > 3){
                            System.Console.WriteLine("\nYou must select enter either 0, 1, or 2.\n");
                        }
                    }
                    while(!isNum || p1choice < 0 || p1choice > 3);

                    round.p1Choice = (Choice)p1choice;
                    //insert the players choices directly into the round
                    // round.p1Choice = (Choice)rand.Next(3);//this will give a random number starting at 0 to arg-1;
                    round.ComputerChoice = (Choice)rand.Next(3);

                    //check the choices to see who won.
                    System.Console.WriteLine("\n------------------ ROUND RESULTS ------------------");
                    if (round.p1Choice == round.ComputerChoice)
                    {
                        round.Outcome = 0; // it’s a tie . the default is 0 so this line is unnecessary.
                        System.Console.WriteLine("\tThis round was a tie");
                    }
                    else if ((int)round.p1Choice == ((int)round.ComputerChoice + 1) % 3)
                    { //If users pick is one more than the computer’s, user wins
                        round.Outcome = 1;
                        System.Console.WriteLine($"\t{p1.Name} wins!");
                    }
                    else
                    { //If it’s not a tie and p1 didn’t win, then computer wins.
                        round.Outcome = 2;
                        System.Console.WriteLine("\tThe Computer wins!");
                    }

                    game.rounds.Add(round);//add this round to the games List of rounds

                    //search the game.rounds List<> to see if one player has 2 wins
                    //if not loop to another round
                    int numP1Wins = game.rounds.Count(x => x.Outcome == 1);//get nhow many rounds p1 has won.
                    int numComputerWins = game.rounds.Count(x => x.Outcome == 2);//get nhow many rounds p1 has won.

                    //assign the winner to the game and increment wins and losses for both
                    System.Console.WriteLine($"{p1.Name}'s wins => {numP1Wins} \tComputer's wins {numComputerWins}");
                    System.Console.WriteLine("---------------------------------------------------");
                    if (numP1Wins == 2)
                    {
                        game.winner = p1;
                        p1.record["wins"]++;//increments wins and losses.
                        computer.record["losses"]++;//increments wins and losses.
                    }
                    else if (numComputerWins == 2)
                    {
                        game.winner = computer;
                        p1.record["losses"]++;//increments wins and losses.
                        computer.record["wins"]++;//increments wins and losses.
                    }

                    //game.winner.Name = "mark";//placeholder to escape loop during testing.


                }//end of rounds loop

                games.Add(game);



                //play rounds till one player has 2 wins
                //record each round into the game

                //record the game

                //increment wins/losses for each player

                //print out the game results - rounds data



            } while (choice != 2);//end of game loop


            PrintAllCurrentData(games, players, rounds);




            //on quitting....
            //print out the win.loss record for all players

        }//end of main

        public static void PrintAllCurrentData(List<Game> games, List<Player> players, List<Round> rounds)
        {
            foreach (var game in games)
            {
                System.Console.WriteLine($"\nPlayer1: {game.Player1.Name}\nPlayer 2: {game.Computer.Name}\n\n\tThe winner is: {game.winner.Name}");
                System.Console.WriteLine($"\n--- Here are the games rounds --- ");
                int i = 0;
                foreach (Round round in game.rounds)
                {
                    System.Console.WriteLine($"\n---------- Round {i} ----------"); i++;
                    System.Console.WriteLine($"{round.player1.Name} chose {round.p1Choice}");
                    System.Console.WriteLine($"{round.Computer.Name} chose {round.ComputerChoice}");
                    if (round.Outcome == 0){
                        System.Console.WriteLine($"This round was a tie.");
                    }
                    else if (round.Outcome == 1){
                        System.Console.WriteLine($"{round.player1.Name} won this round.");
                    }
                    else if (round.Outcome == 2){
                        System.Console.WriteLine($"{round.Computer.Name} won this round.");
                    }


                }
            }
            System.Console.Write("------------------------------\n");
            System.Console.WriteLine("\n--- Here is the list of players. ---");
            foreach (var player in players)
            {
                System.Console.WriteLine($"\nPlayer: {player.Name} \nWins: {player.record["wins"]} Losses: {player.record["losses"]}");
            }

        }

    }//end of program
}//end of namaespace

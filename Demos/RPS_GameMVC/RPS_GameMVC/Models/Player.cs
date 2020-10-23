using System;
using System.Collections.Generic;

namespace RPS_Game_Refactored
{
    public class Player
    {

        public int PlayerID { get; set; } = -1;
        public string Name { get; set; } = "null";

        public int Wins { get; set; } = 0;

        public int Losses { get; set; } = 0;

        public List<Game> games = new List<Game>();
        public Dictionary<string, int> record = new Dictionary<string, int>()
        {
            {"wins", 0},
            {"losses", 0}
        };
        //"wins" = 2
        //"losses" = 3
        //record."wins"++;

    }
}
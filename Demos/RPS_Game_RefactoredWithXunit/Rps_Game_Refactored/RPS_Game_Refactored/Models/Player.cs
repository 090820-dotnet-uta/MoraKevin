using System;
using System.Collections.Generic;

namespace RPS_Game_Refactored
{
    public class Player
    {
        public string Name { get; set; } = "null";

        //public string name;
        //private string name;
        // public void SetName(string name){
        //     this.name = name;
        // }



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
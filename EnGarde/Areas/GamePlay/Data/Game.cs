using System;
using System.Collections.Generic;
using EnGarde.Areas.Identity.Data;

namespace EnGarde.Areas.GamePlay.Data
{
    public class Game
    {
        /// <summary>
        /// Constructs a new game instance
        /// </summary>
        /// <param name="white">The White player</param>
        /// <param name="black">The Black player</param>
        /// <param name="initial">Initial state of the game</param>
        public Game(Player white, Player black, GameState initial) {
            this.Start = DateTime.UtcNow;
            this.White = white;
            this.Black = black;
            this.States = new List<GameState>() { initial };
        }

        public int  GameID { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Player White { get; set;}

        public Player Black { get; set;}

        public List<GameState> States { get; set; }
    }
}

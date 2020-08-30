using System;
using System.Collections.Generic;
using EnGarde.Areas.Identity.Data;

namespace EnGarde.Areas.GamePlay.Data
{
    public class Game
    {
        public int  ID { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Player White { get; set;}

        public Player Black { get; set;}

        public List<BoardState> States { get; set; }
    }
}

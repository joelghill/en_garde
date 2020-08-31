using System;
using System.ComponentModel.DataAnnotations;

namespace EnGarde.Areas.GamePlay.Data
{
    public class GameState 
    {   
        /// <summary>
        /// Creates a new gamestate instance 
        /// </summary>
        /// <param name="state">The board state</param>
        /// <param name="parent">The game this state is associated with</param>
        public GameState(BoardState state, Game parent) {
            this.Created = DateTime.UtcNow;
            this.State = state;
            this.ParentGame = parent;
        }

        /// <summary>
        /// Unique identifier for this instance
        /// </summary>
        [Key]
        public int GameStateID { get; private set; }

        /// <summary>
        /// The current state of the board for this game state instance
        /// </summary>
        public BoardState State { get; private set; }

        /// <summary>
        /// Gets the Date Time this board state was created
        /// </summary>
        public DateTime Created { get; private set; }

        /// <summary>
        /// The game this game state is associated with
        /// </summary>
        public Game ParentGame { get; private set; }
    }
}
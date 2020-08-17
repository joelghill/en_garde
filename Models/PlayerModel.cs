using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace En_Garde.Models
{
    public class PlayerModel
    { 
        [Key]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime Joined { get; set; }

        public List<PlayerModel> Friends { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EnGarde.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Player class
    public class Player : IdentityUser
    {
        
        [Required]
        string Username {get; set;}

        [DataType(DataType.DateTime)]
        DateTime LastLoggedIn {get; set;}

        List<Player> Friends {get; set;}
    }
}

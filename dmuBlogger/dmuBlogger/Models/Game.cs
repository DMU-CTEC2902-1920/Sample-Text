﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Game
    {
        //Primary key for the game class/table
        [Required]
        [Key]
        public virtual Int32 GameId { get; set; }
        //Foreign key - the developer who made the game
        [Required]
        public virtual int DeveloperID { get; set; }
        //Name of the game
        [Required]
        public virtual String GameName { get; set; }
        public virtual String GameGenre { get; set; }
        //Date when the game was/will be released
        public virtual String GameReleaseDate { get; set; }
    }
}
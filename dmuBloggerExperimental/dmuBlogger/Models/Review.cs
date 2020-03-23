using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Review
    {
        //Primary key for the review class/table
        public virtual int ReviewID { get; set; }
        //Title of the review
        [Required]
        public virtual string Title { get; set; }
        //Genre of the revieved game
        public virtual string Genre { get; set; }
        //The actual review
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        //Rating of the game from 1 to 10
        [Required]
        public virtual Int32 Score { get; set; }
        //Developer of the game
        public int DeveloperID { get; set; }
        //What game is being reviewed
        public int GameID { get; set; }
    }
}
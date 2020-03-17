using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Game
    {

        public Game()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public Int32 GameId { get; set; }
        [Required]
        public String GameName { get; set; }
        [Required]
        public String GameReleaseDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
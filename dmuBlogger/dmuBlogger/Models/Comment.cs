using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dmuBlogger.Models
{
    public class Comment
    {

        [Key]
        public Int32 CommentId { get; set; }
        [Required]
        public String CommentContent { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long GameId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

    }
}
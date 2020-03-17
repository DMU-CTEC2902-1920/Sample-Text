using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Comment
    {

        [Required]
        public Int32 CommentId { get; set; }
        [Required]
        public String CommentContent { get; set; }

    }
}
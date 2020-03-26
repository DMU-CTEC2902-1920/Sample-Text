using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Comment
    {
        //Primary key for the comment class/table
        public virtual int CommentID { get; set; }
        //Foreign key - under which review the comment was posted
        public virtual int ReviewID { get; set; }
        //The actual comment
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        //Name of the user who posted comment
        public virtual string Name { get; set; }
        //Email of the user who posted comment
        public virtual string EMail { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Comment
    {
        public virtual int CommentID { get; set; }
        public virtual int ReviewID { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual string EMail { get; set; }
    }
}
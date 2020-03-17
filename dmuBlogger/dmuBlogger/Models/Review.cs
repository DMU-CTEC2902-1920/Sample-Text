using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Review
    {
        public virtual int ReviewID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Genre { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        public virtual Int32 Score { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
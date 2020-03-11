using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmuBlogger.Models
{
    public class Review
    {
        public virtual int ReviewID { get; set; }
        public virtual int GenreId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageURL { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
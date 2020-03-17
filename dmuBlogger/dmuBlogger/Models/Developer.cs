using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmuBlogger.Models
{
    public class Developer
    {
        public virtual int DeveloperId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
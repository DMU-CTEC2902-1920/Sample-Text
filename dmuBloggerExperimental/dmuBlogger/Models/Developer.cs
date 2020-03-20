using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmuBlogger.Models
{
    public class Developer
    {
        //Primary key for the developer class/table
        public virtual int DeveloperId { get; set; }
        //Name of the developer
        public virtual string Name { get; set; }
        //Some details about the developer
        public virtual string Description { get; set; }
    }
}
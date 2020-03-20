using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Blacklist
    {

        //Primary key for the Blacklist table/class
        [Key]
        public virtual int BlacklistId { get; set; }

        //Email to be blacklisted (will not be able to post any more comments)
        [Required]
        public virtual string BlacklistEmail { get; set; }

    }
}
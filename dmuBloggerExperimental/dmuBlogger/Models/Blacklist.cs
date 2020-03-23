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

        //IP to be blacklisted (will not be able to post)
        [Required]
        public virtual string BlacklistIP { get; set; }

        //Reason for being blacklisted, is show to blacklisted users and mods
        public virtual string BlacklistReason { get; set; }

    }
}
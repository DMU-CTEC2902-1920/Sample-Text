using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class User
    {

        [Key]
        public Int32 UserId { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public String UserEmail { get; set; }
        [Required]
        public String UserPassword { get; set; }

        public Boolean UserSuspended { get; set; }

    }
}
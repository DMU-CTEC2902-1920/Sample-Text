using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Developer
    {

        [Key]
        public Int32 DeveloperId { get; set; }
        [Required]
        public String DeveloperName { get; set; }
        [Required]
        public String DeveloperPictureURL { get; set; }
        [Required]
        public String DeveloperWebsiteURL { get; set; }

    }
}
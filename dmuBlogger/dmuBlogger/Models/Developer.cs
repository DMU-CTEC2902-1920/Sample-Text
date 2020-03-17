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
        [Display(Name = "Developer's Name:")]
        public String DeveloperName { get; set; }
        [Required]
        [Display(Name = "Developer's Avatar Link:")]
        public String DeveloperPictureURL { get; set; }
        [Required]
        [Display(Name = "Developer's Website:")]
        public String DeveloperWebsiteURL { get; set; }

    }
}
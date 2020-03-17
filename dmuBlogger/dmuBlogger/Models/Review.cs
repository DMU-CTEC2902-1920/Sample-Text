using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dmuBlogger.Models
{
    public class Review
    {

        [Key]
        public Int32 ReviewId { get; set; }
        [Required]
        public String ReviewTitle { get; set; }
        [Required]
        public String ReviewContent { get; set; }
        [Required]
        public String ReviewScore { get; set; }

    }
}
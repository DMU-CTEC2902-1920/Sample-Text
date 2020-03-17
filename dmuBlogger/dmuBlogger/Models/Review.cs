using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace dmuBlogger.Models
{
    public class Review
    {
        public virtual int ReviewID { get; set; }
        [Required]
        public virtual string Title { get; set; }
        public virtual string Genre { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        [Required]
        public virtual Int32 Score { get; set; }
        public string SelectedDeveloper { get; set; }
        public IEnumerable<SelectListItem> Developer { get; set; }
        public string SelectedGame { get; set; }
        public IEnumerable<SelectListItem> Game { get; set; }
    }
}
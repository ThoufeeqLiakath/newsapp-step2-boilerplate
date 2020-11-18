using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_WebApp.Models
{
    public class News
    {
        [DataType(DataType.Text)]
        [Range(101, 200, ErrorMessage = "Enter a value between 101 and 200")]
        [RegularExpression("^(0|[1-9][0-9]*)$", ErrorMessage = "Enter number")]
        public int NewsId { get; set; }

        [Required(ErrorMessage = "Title is mandatory")]
        public string Title { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Content is mandatory")]
        public string Content { get; set; }


        [Required(ErrorMessage = "Published date is mandatory")]
        [DataType(DataType.Date)]
        [Display(Name = "Publishing Date")] 
        public DateTime PublishedAt { get; set; }
        
        [Required(ErrorMessage = "Image is mandatory")]
        [Display(Name = "Select an image to upload")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\(\):])+(.png|.jpg|.jpeg)$", ErrorMessage = "Upload an image")]
        public string UrlToImage { get; set; }  
        //[ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        //[NotMapped]
        //public List<News> AllNews { get; set; }
    }
}

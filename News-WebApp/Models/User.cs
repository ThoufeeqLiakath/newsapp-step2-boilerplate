using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News_WebApp.Models
{
    public class User
    {
        [Required(ErrorMessage ="Username is mandatory")]
        public string UserId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }

        public virtual ICollection<News> NewsList { get; set; }
    }
}

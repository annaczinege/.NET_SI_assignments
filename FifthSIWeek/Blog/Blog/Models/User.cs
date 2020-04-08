using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        public List<Post> Posts { get; set; }

    }
}

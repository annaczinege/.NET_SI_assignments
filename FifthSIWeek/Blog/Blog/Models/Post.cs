using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }

    }
}
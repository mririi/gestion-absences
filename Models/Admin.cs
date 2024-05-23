using System.ComponentModel.DataAnnotations;

namespace gestionabscence.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string Type { get; set; }
    }
}

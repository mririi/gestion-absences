using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionabscence.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        [Column(TypeName ="varchar(8)")]
        public string? IdCard { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [Column(TypeName ="varchar(2000)")]
        public string? Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(8)")]
        public string Phone { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Role { get; set; } = "Student";

        // Navigation properties
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Professor>? Professors { get; set; }
        public virtual ICollection<Admin>? Admins { get; set; }
    }
}

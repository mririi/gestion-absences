using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace gestionabscence.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public virtual Group? Group { get; set; }

        // Navigation property
        public virtual ICollection<Absences>? Absences { get; set; }
    }
}

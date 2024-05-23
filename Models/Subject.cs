using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionabscence.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        public int HoursNumber { get; set; }

        [Required]
        public string SubjectType { get; set; }

        public virtual ICollection<ProfessorSubjectAssignment> ProfessorSubjectAssignments { get; set; }
        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
    }
}

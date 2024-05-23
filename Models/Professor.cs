using System.ComponentModel.DataAnnotations;

namespace gestionabscence.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ProfessorSubjectAssignment> ProfessorSubjectAssignments { get; set; }
    }
}

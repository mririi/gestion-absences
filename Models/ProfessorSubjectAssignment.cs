namespace gestionabscence.Models
{
    public class ProfessorSubjectAssignment
    {
        public int AssignmentId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace gestionabscence.Models
{
    public class GroupSubject
    {
        [Key]
        public int GroupSubjectId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
     
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}

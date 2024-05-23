using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionabscence.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
    }
}

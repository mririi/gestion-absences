namespace GestionAbscences.ViewModel
{
    public class AbsencesEditViewModel
    {
        public int StudentId { get; set; }
        public int AbsenceId { get; set; }

        public DateTime Date { get; set; }

        public int HoursNumber { get; set; }
        public string FullName { get; set; }
    }

}

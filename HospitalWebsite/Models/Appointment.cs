public class Appointment
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime PreferredDate { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}

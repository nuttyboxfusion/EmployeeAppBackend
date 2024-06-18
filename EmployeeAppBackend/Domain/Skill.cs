namespace EmployeeAppBackend.Domain
{
    public class Skill
    {

        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public ReflistSeniorityLevel SeniorityLevel { get; set; }
        public string EmployeeId { get; set; }  // Foreign key to Employee
        public Employee Employee { get; set; }

    }
}

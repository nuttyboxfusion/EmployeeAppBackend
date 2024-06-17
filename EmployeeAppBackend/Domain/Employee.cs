using System.Net;

namespace EmployeeAppBackend.Domain
{
    public class Employee
    {
        public Employee()
        {
            Skills = new List<Skill>();
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public List<Skill> Skills { get; set; }

       


    }
}

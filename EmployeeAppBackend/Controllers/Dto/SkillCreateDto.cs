using EmployeeAppBackend.Domain;

namespace EmployeeAppBackend.Controllers.Dto
{
    public class SkillCreateDto
    {
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public ReflistSeniorityLevel SeniorityLevel { get; set; }
        public string? EmployeeId { get; set; }
    }
}

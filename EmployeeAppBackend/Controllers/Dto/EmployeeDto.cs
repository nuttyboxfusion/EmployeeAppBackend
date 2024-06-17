namespace EmployeeAppBackend.Controllers.Dto
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
}

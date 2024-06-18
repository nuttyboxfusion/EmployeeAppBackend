namespace EmployeeAppBackend.Controllers.Dto
{
    public class EmployeeCreateDto
    {
   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
        public List<SkillCreateDto> Skills { get; set; }
    }
}

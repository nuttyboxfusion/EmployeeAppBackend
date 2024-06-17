﻿using EmployeeAppBackend.Domain;

namespace EmployeeAppBackend.Controllers.Dto
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int YearsOfExperience { get; set; }
        public ReflistSeniorityLevel SeniorityLevel { get; set; }
        public string? EmployeeId { get; set; }
    }
}

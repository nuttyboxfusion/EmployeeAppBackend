using AutoMapper;
using EmployeeAppBackend.Controllers.Dto;
using EmployeeAppBackend.Infrastructue;
using System.Text;

namespace EmployeeAppBackend.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeManager
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private static Random random = new Random();

        public EmployeeManager(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(string id)
        {
            var employee = await _employeeRepository.GetByStringIdAsync(id);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeCreateDto)
        {

            foreach (var skill in employeeCreateDto.Skills)
            {
                skill.EmployeeId = employeeCreateDto.Id;
            }
            var employee = _mapper.Map<Employee>(employeeCreateDto);
            employee.Id = GenerateEmployeeId();

            employee.Address = _mapper.Map<Address>(employeeCreateDto.Address);

            employee.Skills = employeeCreateDto.Skills.Select(s => _mapper.Map<Skill>(s)).ToList();

            await _employeeRepository.AddAsync(employee);

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> EditEmployeeAsync(string id, EmployeeDto employeeEditDto)
        {
            var existingEmployee = await _employeeRepository.GetByStringIdAsync(id);

            if (existingEmployee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }

            _mapper.Map(employeeEditDto, existingEmployee);

            if (employeeEditDto.Address != null)
            {
                _mapper.Map(employeeEditDto.Address, existingEmployee.Address);
            }

            if (employeeEditDto.Skills != null)
            {
                // Clear existing skills and add new ones
                existingEmployee.Skills.Clear();
                existingEmployee.Skills.AddRange(employeeEditDto.Skills.Select(s => _mapper.Map<Skill>(s)));
            }

            await _employeeRepository.UpdateAsync(existingEmployee);

            return _mapper.Map<EmployeeDto>(existingEmployee);
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            var existingEmployee = await _employeeRepository.GetByStringIdAsync(id);
            if (existingEmployee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }

            await _employeeRepository.DeleteAsync(existingEmployee.Id);
        }


        # region
       
        public static string GenerateEmployeeId()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sb = new StringBuilder(6);

            // Add two random uppercase letters
            for (int i = 0; i < 2; i++)
            {
                sb.Append(letters[random.Next(letters.Length)]);
            }

            // Add four random digits
            for (int i = 0; i < 4; i++)
            {
                sb.Append(random.Next(10)); // 0 to 9
            }

            return sb.ToString();
        }
        #endregion

    }
}


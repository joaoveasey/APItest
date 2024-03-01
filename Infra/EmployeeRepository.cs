using APItest.Model;

namespace APItest.Infra
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        void IEmployeeRepository.Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        List<Employee> IEmployeeRepository.Get()
        {
            return _context.Employees.ToList();
        }
    }
}

using APItest.Model;

namespace APItest.Infra
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public Employee Get(int id)
        {
            return _context.Employees.Find(id);
        }

        void IEmployeeRepository.Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        List<Employee> IEmployeeRepository.Get()
        {
            return _context.Employees.ToList();
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}

namespace APItest.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);    
        List<Employee> Get();
        Employee Get(int id);
        void Remove(Employee employee);
        void Patch(Employee employee);
    }
}

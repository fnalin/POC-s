using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoWebApiOwin.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }

    public interface IEmployeeRepository
    {
        Employee Add(Employee emp);
        Task<Employee> AddAsync(Employee emp);

        Employee Update(Employee emp);
        Task<Employee> UpdateAsync(Employee emp);

        Employee Delete(int id);
        Task<Employee> DeleteAsync(int id);

        IEnumerable<Employee> GetAll();
        Task<IEnumerable<Employee>> GetAllAsync();

        Employee GetById(int id);
        Task<Employee> GetByIdAsync(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {

        private static IList<Employee> _employees =
            new List<Employee>{
                new Employee { Id = 1, Name="Fabiano Nalin", Age=37, Department="TI"},
                new Employee { Id = 2, Name="Priscila Mitui", Age=38, Department="Finance"},
                new Employee { Id = 3, Name="Rafael Goes", Age=77, Department="RH"},
            };

        public Employee Add(Employee emp)
        {
            Thread.Sleep(2000);
            emp.Id = _employees.Count + 1;
            _employees.Add(emp);
            return emp;
        }

        public Task<Employee> AddAsync(Employee emp)
        {
            var tEmp = Task.Run(() =>
            {
                Task.Delay(2000);
                emp.Id = _employees.Count + 1;
                _employees.Add(emp);
                return emp;
            });

            return tEmp;

        }

        public Employee Update(Employee emp)
        {
            Thread.Sleep(2000);
            var _cli = GetById(emp.Id);
            _cli.Name = emp.Name;
            _cli.Age = emp.Age;
            _cli.Department = emp.Department;
            return _cli;
        }
        public Task<Employee> UpdateAsync(Employee emp)
        {
            return Task.Run(() =>
            {
                var data = GetById(emp.Id);
                if (data == null) return null;
                data.Name = emp.Name;
                data.Age = emp.Age;
                data.Department = emp.Department;
                return data;
            });

        }


        public Employee Delete(int id)
        {
            Thread.Sleep(2000);

            var cli = GetById(id);

            if (cli == null)
                return null;

            _employees.Remove(cli);

            return cli;
        }
        public Task<Employee> DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                Task.Delay(2000);
                var cli = GetById(id);

                if (cli == null)
                    return null;

                _employees.Remove(cli);
                return cli;

            });
        }


        public IEnumerable<Employee> GetAll()
        {
            Thread.Sleep(2000);

            return _employees;
        }
        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                Task.Delay(2000);
                return _employees.AsEnumerable();
            });
        }


        public Employee GetById(int id)
        {
            Thread.Sleep(2000);
            return _employees.FirstOrDefault(c => c.Id == id);
        }
        public Task<Employee> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                Task.Delay(2000);
                return _employees.FirstOrDefault(c => c.Id == id);
            });
        }



    }
}

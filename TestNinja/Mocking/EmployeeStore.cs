using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    class EmployeeStore : IEmployeeStore
    {
        public void getEmployee(int id)
        {
            //  List<Employee> lstEmployee = new List<Employee>();
            var _db = new EmployeeContext();

            var employee = _db.Employees.Find(id);
            if (employee == null) return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();

            
        }
    }
}

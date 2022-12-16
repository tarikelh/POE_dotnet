using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTest.DAO
{
    internal class EmployeeDaoImpl : IEmployeeDAO
    {
        private firstdemo_db_prepaEntities1 _context;
        public EmployeeDaoImpl()
        {
            _context = new firstdemo_db_prepaEntities1();
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.Entry(employee).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();
        }
    }
}

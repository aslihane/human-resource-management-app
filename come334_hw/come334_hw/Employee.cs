using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Aslıhan Erkan
// 20180301032

namespace come334_hw
{
    public class Employee
    {
        public string nameOfEmployee;
        public string favLang;
        public List<Certificate> certificatesOfEmployee = new List<Certificate>();
    }


    public class Department
    {
        public string nameOfDepartment;
        public List<Employee> departmentEmployeeList = new List<Employee>();
    }

    public class Certificate
    {
        public string title;
        public string year;
    }

}

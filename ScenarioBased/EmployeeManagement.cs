namespace ScenarioBased
{
    
    public class Employee
    {
        public int EmployeeId{get;set;}
        public string Name{get; set;}
        public string Department{get;set;}
        public double Salary{get;set;}
        public DateTime JoiningDate{get;set;}

        public Employee()
        {
            
        }

        public override string ToString()
        {
            return $"Employee Id: {EmployeeId}, Employee Name: {Name}, Department: {Department}, Salary: {Salary}";
        }
    }

    public class HRManager
    {
        public int id = 1;
        public List<Employee> employees = new List<Employee>();
        public void AddEmployee(string name, string dept, double salary)
        {
           
            int currentId = id;
            id++;

            employees.Add( new Employee{
                EmployeeId = currentId,
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = DateTime.Today
        });
        }

        public SortedDictionary<string,List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string, List<Employee>> groupEmployee = new SortedDictionary<string, List<Employee>>();

            if(employees == null)
            {
                return groupEmployee;
            }

            foreach(var item in employees)
            {
                if (!groupEmployee.ContainsKey(item.Department))
                {
                    groupEmployee[item.Department] = new List<Employee>();
                }
                groupEmployee[item.Department].Add(item);
            }

            return groupEmployee;
        }

        public double CalculateDepartmentSalary(string department)
        {
            double totalSalary = 0;
            foreach(var item in employees)
            {
                if(item.Department == department)
                {
                    totalSalary += item.Salary;
                }
            }

            return totalSalary;
        }

        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            List<Employee> employeesJoining = new List<Employee>();

            foreach(var item in employees)
            {
                if(item.JoiningDate > date)
                {
                    employeesJoining.Add(item);
                }
            }

            return employeesJoining;
        }

    }

    public class Program
    {   
        public static void Main(string[] args)
        {
            HRManager hr = new HRManager();

            hr.AddEmployee("Amit", "IT", 60000);
            hr.AddEmployee("Neha", "HR", 45000);
            hr.AddEmployee("Rahul", "IT", 75000);
            hr.AddEmployee("Sneha", "Finance", 55000);
            hr.AddEmployee("Karan", "HR", 50000);
            hr.AddEmployee("Pooja", "IT", 68000);
            hr.AddEmployee("Arjun", "Sales", 52000);

            SortedDictionary<string, List<Employee>> groupEmployee = new SortedDictionary<string, List<Employee>>();
            groupEmployee = hr.GroupEmployeesByDepartment();

            foreach(var item in groupEmployee)
            {
                Console.WriteLine($"Dept: {item.Key}");

                foreach(var employee in item.Value)
                {
                    Console.WriteLine(employee);
                }
            }

            double totalSalary = hr.CalculateDepartmentSalary("IT");

            Console.WriteLine($"The Total Salary of IT dept is {totalSalary}");

            List<Employee> employees = new List<Employee>();

            employees = hr.GetEmployeesJoinedAfter(DateTime.Today);

            foreach(var item in employees)
            {
                Console.WriteLine(item);
            }

        }
    }
}
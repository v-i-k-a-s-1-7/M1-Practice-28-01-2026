using System.ComponentModel.DataAnnotations;

namespace  LinqExercises
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Department: {Department}, Age: {Age}, IsActive: {IsActive}";
        }
    }

    public class Program
    {
        
        public static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User { Id = 1, Name = "Vikas", Department = "IT", Age = 24, Salary = 60000, IsActive = true },
                new User { Id = 2, Name = "Aman", Department = "HR", Age = 30, Salary = 40000, IsActive = false },
                new User { Id = 3, Name = "Riya", Department = "IT", Age = 27, Salary = 80000, IsActive = true },
                new User { Id = 4, Name = "Neha", Department = "Finance", Age = 29, Salary = 50000, IsActive = true },
                new User { Id = 5, Name = "Arjun", Department = "HR", Age = 35, Salary = 45000, IsActive = false },
                new User { Id = 6, Name = "Sneha", Department = "IT", Age = 26, Salary = 70000, IsActive = true },
                new User { Id = 7, Name = "Rahul", Department = "Finance", Age = 32, Salary = 55000, IsActive = true },
                new User { Id = 8, Name = "Priya", Department = "IT", Age = 23, Salary = 62000, IsActive = false }
            };
            
            // All the Active Users
            var activeUsers = users.Where(e => e.IsActive == true);

            Console.WriteLine();
            Console.WriteLine("------All The Active Users------");
            foreach(var user in activeUsers)
            {
                Console.WriteLine(user);
            }

            var highSalaries = users.Where(e => e.Salary > 50000)
                                    .Select(e=> new
                                    {
                                            e.Name,
                                            e.Salary                                        
                                    }); 

            Console.WriteLine();
            Console.WriteLine("------All The Users Who have salary greater than 50,000------");
            foreach(var user in highSalaries)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine();
            var countItUsers = users.Count(e=> e.Department == "IT");
            Console.WriteLine($"The Number of IT Users is {countItUsers}");

            Console.WriteLine();
            //Check if any inactive user exists.
            bool InActiveUsers = users.Any(e=> e.IsActive == false);
            if (InActiveUsers)
            {
                Console.WriteLine("Yes Inactive users exist ");
            }
            else
            {
                Console.WriteLine("No Inactive users present");
            }

            //Sort users by salary descending.
            Console.WriteLine();
            Console.WriteLine("------Salaries Descending------");

            var salariesDesc = users.OrderByDescending(e=> e.Salary);
            foreach(var user in salariesDesc)
            {
                Console.WriteLine($"Name: {user.Name}, Salary: {user.Salary}");
            }

            
            // Get highest paid user.
            Console.WriteLine();
            var highestPaidUser = users.MaxBy(e=> e.Salary);
            Console.WriteLine($"The Max Salary is of User {highestPaidUser.Name} and his/her salary is {highestPaidUser.Salary}");

            Console.WriteLine();
            var totalItSalary = users.Where(e=> e.Department == "IT").Sum(e=> e.Salary);
            Console.WriteLine($"The sum of It Dept's Salary is {totalItSalary}"); 

            Console.WriteLine();
            var averageHrSalary = users.Where(e=> e.Department == "HR").Average(e=> e.Salary);
            Console.WriteLine($"The Average Salary of HR Dept is {averageHrSalary}");

            Console.WriteLine();
            var topThreePaid = users.OrderByDescending(e=> e.Salary).Take(3);
            foreach(var user in topThreePaid)
            {
                System.Console.WriteLine($"Name: {user.Name}, Salary: {user.Salary}");
            }

            System.Console.WriteLine();
            var youngestActive = users.Where(e=> e.IsActive == true).OrderBy(e=>e.Age).First();
            System.Console.WriteLine($"The Youngest Employee is {youngestActive}");

            // Group users by Department.
            System.Console.WriteLine();
            var groupDept = users.GroupBy(e=> e.Department);

            foreach(var group in groupDept)
            {
                System.Console.WriteLine($"Deprtment : {group.Key}");

                foreach(var item in group)
                {
                    System.Console.WriteLine();
                }
            }

            System.Console.WriteLine();
            var groupDeptAverage = users.GroupBy(e=> e.Department)
                                        .Select( e=> new
                                        {
                                            DepartmentName = e.Key,
                                            TotalEmployee = e.Count(),
                                            AverageSalary = e.Average()
                                        });
            
            foreach(var item in groupDeptAverage)
            {
                System.Console.WriteLine($"{groupDeptAverage.Key} -> {}");
            }
            
        }
    }

}
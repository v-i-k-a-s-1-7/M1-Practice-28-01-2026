namespace Generics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Student s1 = new Student(101,"Vikas",new List<int>{85,96,91});
            Student s2 = new Student(102,"Chaitanya",new List<int>{95,76,81});
            Student s3 = new Student(103,"Abhinandan",new List<int>{88,84,89});
            Student s4 = new Student(104,"Asad",new List<int>{95,86,93});
            
            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);

            var rank =  students
                        .OrderByDescending(s=> s.AverageMarks)
                        .ToList();

            foreach(var item in rank)
            {
                Console.WriteLine($"Name: {item.Name} , Average Marks: {item.AverageMarks:F2}");
            }
        }
    }
}
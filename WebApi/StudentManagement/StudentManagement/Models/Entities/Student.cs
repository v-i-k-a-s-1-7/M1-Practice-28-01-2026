namespace StudentManagement.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Course { get; set; }
    }
}

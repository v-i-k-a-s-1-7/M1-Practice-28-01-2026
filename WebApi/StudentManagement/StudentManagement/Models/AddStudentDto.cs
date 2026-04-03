namespace StudentManagement.Models
{
    public class AddStudentDto
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Course { get; set; }
    }
}

namespace StudentMarks.Models.Entities
{
    public class SubjectMarks
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal MathMarks { get; set; }
        public decimal PhyMarks { get; set; }
        public decimal ChemMarks { get; set; }

    }
}

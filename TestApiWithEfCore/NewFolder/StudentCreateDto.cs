namespace TestApiWithEfCore.NewFolder
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public List<EnrollmentCreateDto> Enrollments { get; set; }
    }

    public class EnrollmentCreateDto
    {
        public int CourseId { get; set; }
        public string Grade { get; set; }
    }

}

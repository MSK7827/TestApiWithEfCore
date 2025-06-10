using System.Text.Json.Serialization;

namespace TestApiWithEfCore.NewFolder
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        public required ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public required ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        public string Grade { get; set; }
    }

}

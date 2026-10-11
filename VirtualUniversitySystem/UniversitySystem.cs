using System.Collections.Generic;

namespace VirtualUniversitySystem
{
    public class UniversitySystem
    {
        public List<Student> Students = new List<Student>();
        public List<Teacher> Teachers = new List<Teacher>();
        public AffairsOfficer Affairs = new AffairsOfficer("MXM", "123");
        public List<string> AvailableCourses = new List<string>();
        public Dictionary<string, string> CourseQuestions = new Dictionary<string, string>();
    }
}
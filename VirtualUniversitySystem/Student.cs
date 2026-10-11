using System.Collections.Generic;

namespace VirtualUniversitySystem
{
    public class Student
    {
        public string Username;
        public string Password;
        public string FullName;
        public List<string> RegisteredCourses = new List<string>();
        public List<string> ExamCourses = new List<string>();
        public List<string> ExamAnswersList = new List<string>();
        public List<string> GradeCourses = new List<string>();
        public List<int> GradeValues = new List<int>();

        public Student(string u, string p, string name)
        {
            Username = u;
            Password = p;
            FullName = name;
        }
    }
}
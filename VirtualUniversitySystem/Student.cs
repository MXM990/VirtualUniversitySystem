using System.Collections.Generic;

namespace VirtualUniversitySystem
{
    public class Student
    {
        public string Username;
        public string Password;
        public string FullName;
        public List<string> RegisteredCourses = new List<string>();
        public Dictionary<string, int> Grades = new Dictionary<string, int>();

        public Student(string u, string p, string name)
        {
            Username = u;
            Password = p;
            FullName = name;
        }
    }
}
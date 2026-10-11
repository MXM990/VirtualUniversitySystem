using System;
using System.Collections.Generic;

namespace VirtualUniversitySystem
{
    public class UniversitySystem
    {
        public List<Student> Students = new List<Student>();
        public List<Teacher> Teachers = new List<Teacher>();
        public AffairsOfficer Affairs = new AffairsOfficer("mxm", "123");
        public List<string> AvailableCourses = new List<string>();

        public List<string> CourseNames = new List<string>();
        public List<string> CourseQuestions = new List<string>();


        public static void CheckAvailbleCours(List<string> availableCourses )
        {
            if (availableCourses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            Console.WriteLine("Available Courses:");
            for (int i = 0; i < availableCourses.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + availableCourses[i]);
            }

        }
    }
}
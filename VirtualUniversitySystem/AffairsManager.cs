using System;
using System.Collections.Generic;

namespace VirtualUniversitySystem
{
    public static class AffairsManager
    {
        public static void RunDashboard(UniversitySystem university)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Student Affairs Dashboard ===");
                Console.WriteLine("1. Add New Teacher");
                Console.WriteLine("2. Add New Course");
                Console.WriteLine("3. Add New Student");
                Console.WriteLine("4. Logout");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddNewTeacher(university.Teachers);
                }
                else if (choice == "2")
                {
                    AddNewCourse(university.AvailableCourses);
                }
                else if (choice == "3")
                {
                    AddNewStudent(university.Students);
                }
                else if (choice == "4")
                {
                    break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void AddNewTeacher(List<Teacher> teachers)
        {
            Console.Write("Enter Teacher Username: ");
            string u = Console.ReadLine();
            Console.Write("Enter Password: ");
            string p = Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            teachers.Add(new Teacher(u, p, name));
            Console.WriteLine("Teacher added successfully!");
        }

        private static void AddNewCourse(List<string> availableCourses)
        {
            Console.Write("Enter Course Name: ");
            string course = Console.ReadLine();

            bool exists = false;
            for (int i = 0; i < availableCourses.Count; i++)
            {
                if (availableCourses[i] == course)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                availableCourses.Add(course);
                Console.WriteLine("Course added successfully!");
            }
            else
            {
                Console.WriteLine("Course already exists.");
            }
        }

        private static void AddNewStudent(List<Student> students)
        {
            Console.Write("Enter Student Username: ");
            string u = Console.ReadLine();
            Console.Write("Enter Password: ");
            string p = Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            students.Add(new Student(u, p, name));
            Console.WriteLine("Student added successfully!");
        }
    }
}
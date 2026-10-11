using System;
using System.Collections.Generic;

namespace VirtualUniversitySystem
{
    public static class StudentManager
    {
        public static void RunDashboard(Student student, UniversitySystem university)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Student Dashboard: " + student.FullName + " ===");
                Console.WriteLine("1. Register for Course");
                Console.WriteLine("2. Take Exam");
                Console.WriteLine("3. View Grades");
                Console.WriteLine("4. Logout");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    RegisterForCourse(student, university.AvailableCourses);
                }
                else if (choice == "2")
                {
                    TakeExam(student, university.CourseQuestions);
                }
                else if (choice == "3")
                {
                    ViewGrades(student);
                }
                else if (choice == "4")
                {
                    break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void RegisterForCourse(Student student, List<string> availableCourses)
        {
            if (availableCourses.Count == 0)
            {
                Console.WriteLine("No courses available to register.");
                return;
            }

            Console.WriteLine("Available Courses:");
            for (int i = 0; i < availableCourses.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + availableCourses[i]);
            }

            Console.Write("Enter course name to register: ");
            string cName = Console.ReadLine();

            bool courseExists = false;
            for (int i = 0; i < availableCourses.Count; i++)
            {
                if (availableCourses[i] == cName)
                {
                    courseExists = true;
                    break;
                }
            }

            if (courseExists)
            {
                bool alreadyRegistered = false;
                for (int i = 0; i < student.RegisteredCourses.Count; i++)
                {
                    if (student.RegisteredCourses[i] == cName)
                    {
                        alreadyRegistered = true;
                        break;
                    }
                }

                if (!alreadyRegistered)
                {
                    student.RegisteredCourses.Add(cName);
                    Console.WriteLine("Registered successfully!");
                }
                else
                {
                    Console.WriteLine("You are already registered in this course.");
                }
            }
            else
            {
                Console.WriteLine("Course does not exist.");
            }
        }

        private static void TakeExam(Student student, Dictionary<string, string> courseQuestions)
        {
            Console.Write("Enter course name for exam: ");
            string cName = Console.ReadLine();

            if (courseQuestions.ContainsKey(cName))
            {
                Console.WriteLine("\nQuestion: " + courseQuestions[cName]);
                Console.Write("Your Answer: ");
                Console.ReadLine();
                Console.WriteLine("Answer submitted successfully!");
            }
            else
            {
                Console.WriteLine("No question available for this course.");
            }
        }

        private static void ViewGrades(Student student)
        {
            Console.WriteLine("\n--- Your Grades ---");
            if (student.Grades.Count == 0)
            {
                Console.WriteLine("No grades yet.");
            }
            else
            {
                foreach (var item in student.Grades)
                {
                    Console.WriteLine("Course: " + item.Key + " | Grade: " + item.Value);
                }
            }
        }
    }
}
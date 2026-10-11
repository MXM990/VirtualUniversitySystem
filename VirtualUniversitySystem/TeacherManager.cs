using System;
using System.Collections.Generic;

namespace VirtualUniversitySystem
{
    public static class TeacherManager
    {
        public static void RunDashboard(Teacher teacher, UniversitySystem university)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Teacher Dashboard: " + teacher.FullName + " ===");
                Console.WriteLine("1. Set Course Question");
                Console.WriteLine("2. View Enrolled Students");
                Console.WriteLine("3. Submit Student Grade");
                Console.WriteLine("4. Logout");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    SetCourseQuestion(university.AvailableCourses, university.CourseQuestions);
                }
                else if (choice == "2")
                {
                    ViewEnrolledStudents(university.Students);
                }
                else if (choice == "3")
                {
                    SubmitStudentGrade(university.Students);
                }
                else if (choice == "4")
                {
                    break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void SetCourseQuestion(List<string> availableCourses, Dictionary<string, string> courseQuestions)
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

            Console.Write("Enter course name: ");
            string cName = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < availableCourses.Count; i++)
            {
                if (availableCourses[i] == cName)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.Write("Enter question: ");
                string q = Console.ReadLine();
                courseQuestions[cName] = q;
                Console.WriteLine("Question saved successfully!");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        private static void ViewEnrolledStudents(List<Student> students)
        {
            Console.Write("Enter course name to view students: ");
            string cName = Console.ReadLine();

            Console.WriteLine("\nStudents enrolled in " + cName + ":");
            bool found = false;
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < students[i].RegisteredCourses.Count; j++)
                {
                    if (students[i].RegisteredCourses[j] == cName)
                    {
                        Console.WriteLine("- " + students[i].FullName);
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine("No students found.");
        }

        private static void SubmitStudentGrade(List<Student> students)
        {
            Console.Write("Enter Student Username: ");
            string sUser = Console.ReadLine();

            Student targetStudent = null;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Username == sUser)
                {
                    targetStudent = students[i];
                    break;
                }
            }

            if (targetStudent != null)
            {
                Console.Write("Enter Course Name: ");
                string cName = Console.ReadLine();

                Console.Write("Enter Grade (0-100): ");
                int grade = Convert.ToInt32(Console.ReadLine());

                targetStudent.Grades[cName] = grade;
                Console.WriteLine("Grade recorded successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
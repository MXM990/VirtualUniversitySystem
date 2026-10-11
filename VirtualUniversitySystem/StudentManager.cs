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
                    TakeExam(student,  university.CourseNames, university.CourseQuestions);
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
            UniversitySystem.CheckAvailbleCours(availableCourses);

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

        private static void TakeExam(Student student, List<string> courseNames, List<string> courseQuestions)
        {
            if (student.RegisteredCourses.Count == 0)
            {
                Console.WriteLine("You are not registered in any courses yet.");
                return;
            }

            Console.WriteLine("Your Registered Courses:");
            for (int i = 0; i < student.RegisteredCourses.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + student.RegisteredCourses[i]);
            }

            Console.Write("Enter course name to take exam: ");
            string cName = Console.ReadLine();

            bool isRegistered = false;
            for (int i = 0; i < student.RegisteredCourses.Count; i++)
            {
                if (student.RegisteredCourses[i] == cName)
                {
                    isRegistered = true;
                    break;
                }
            }

            if (isRegistered)
            {
                string questionText = "";
                for (int i = 0; i < courseNames.Count; i++)
                {
                    if (courseNames[i] == cName)
                    {
                        questionText = courseQuestions[i];
                        break;
                    }
                }

                if (questionText != "")
                {
                    Console.WriteLine("\nQuestion: " + questionText);
                    Console.Write("Your Answer: ");
                    string answer = Console.ReadLine();

                    bool alreadyAnswered = false;
                    for (int i = 0; i < student.ExamCourses.Count; i++)
                    {
                        if (student.ExamCourses[i] == cName)
                        {
                            student.ExamAnswersList[i] = answer;
                            alreadyAnswered = true;
                            break;
                        }
                    }

                    if (!alreadyAnswered)
                    {
                        student.ExamCourses.Add(cName);
                        student.ExamAnswersList.Add(answer);
                    }

                    Console.WriteLine("Exam submitted successfully!");
                }
                else
                {
                    Console.WriteLine("No question available for this course yet.");
                }
            }
            else
            {
                Console.WriteLine("You are not registered in this course.");
            }
        }

        private static void ViewGrades(Student student)
        {
            Console.WriteLine("\n--- Your Grades ---");
            if (student.GradeCourses.Count == 0)
            {
                Console.WriteLine("No grades yet.");
            }
            else
            {
                for (int i = 0; i < student.GradeCourses.Count; i++)
                {
                    Console.WriteLine("Course: " + student.GradeCourses[i] + " | Grade: " + student.GradeValues[i]);
                }
            }
        }
    }
}
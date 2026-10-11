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
                    SetCourseQuestion(university.AvailableCourses, university.CourseNames, university.CourseQuestions);
                }
                else if (choice == "2")
                {
                    ViewEnrolledStudents(university); // or  send only UniversitySystem
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

        private static void SetCourseQuestion(List<string> availableCourses, List<string> courseNames, List<string> courseQuestions)
        {
            UniversitySystem.CheckAvailbleCours(availableCourses);

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

                bool updated = false;
                for (int i = 0; i < courseNames.Count; i++)
                {
                    if (courseNames[i] == cName)
                    {
                        courseQuestions[i] = q;
                        updated = true;
                        break;
                    }
                }

                if (!updated)
                {
                    courseNames.Add(cName);
                    courseQuestions.Add(q);
                }

                Console.WriteLine("Question saved successfully!");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        private static void ViewEnrolledStudents(UniversitySystem university)
        {
            UniversitySystem.CheckAvailbleCours(university.AvailableCourses);

            Console.Write("Enter course name to view students: ");
            string cName = Console.ReadLine();

            Console.WriteLine("\nStudents enrolled in " + cName + ":");
            bool found = false;
            for (int i = 0; i < university.Students.Count; i++)
            {
                for (int j = 0; j < university.Students[i].RegisteredCourses.Count; j++)
                {
                    if (university.Students[i].RegisteredCourses[j] == cName)
                    {
                        Console.WriteLine("- " + university.Students[i].FullName + " (Username: " + university.Students[i].Username + ")");
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("No students found.");
            }
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

                bool isRegistered = false;
                for (int i = 0; i < targetStudent.RegisteredCourses.Count; i++)
                {
                    if (targetStudent.RegisteredCourses[i] == cName)
                    {
                        isRegistered = true;
                        break;
                    }
                }

                if (isRegistered)
                {
                    Console.WriteLine("\n--- Student Exam Details ---");
                    Console.WriteLine("Student: " + targetStudent.FullName);
                    Console.WriteLine("Course: " + cName);

                    string studentAnswer = "[No answer submitted yet]";
                    for (int i = 0; i < targetStudent.ExamCourses.Count; i++)
                    {
                        if (targetStudent.ExamCourses[i] == cName)
                        {
                            studentAnswer = targetStudent.ExamAnswersList[i];
                            break;
                        }
                    }

                    Console.WriteLine("Student's Answer: " + studentAnswer);

                    Console.Write("\nEnter Grade (0-100): ");
                    int grade = Convert.ToInt32(Console.ReadLine());

                    bool gradeUpdated = false;
                    for (int i = 0; i < targetStudent.GradeCourses.Count; i++)
                    {
                        if (targetStudent.GradeCourses[i] == cName)
                        {
                            targetStudent.GradeValues[i] = grade;
                            gradeUpdated = true;
                            break;
                        }
                    }

                    if (!gradeUpdated)
                    {
                        targetStudent.GradeCourses.Add(cName);
                        targetStudent.GradeValues.Add(grade);
                    }

                    Console.WriteLine("Grade recorded successfully!");
                }
                else
                {
                    Console.WriteLine("Student is not registered in this course.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
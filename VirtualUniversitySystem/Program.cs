using System;

namespace VirtualUniversitySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversitySystem university = new UniversitySystem();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Virtual University System ===");
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (username == university.Affairs.Username && password == university.Affairs.Password)
                {
                    AffairsManager.RunDashboard(university);
                }
                else
                {
                    Teacher teacher = FindTeacher(username, password, university);
                    if (teacher != null)
                    {
                        TeacherManager.RunDashboard(teacher, university);
                    }
                    else
                    {
                        Student student = FindStudent(username, password, university);
                        if (student != null)
                        {
                            StudentManager.RunDashboard(student, university);
                        }
                        else
                        {
                            Console.WriteLine("\nError: Invalid Username or Password!");
                            Console.WriteLine("Press any key to try again...");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        private static Teacher FindTeacher(string username, string password, UniversitySystem university)
        {
            for (int i = 0; i < university.Teachers.Count; i++)
            {
                if (university.Teachers[i].Username == username && university.Teachers[i].Password == password)
                {
                    return university.Teachers[i];
                }
            }
            return null;
        }

        private static Student FindStudent(string username, string password, UniversitySystem university)
        {
            for (int i = 0; i < university.Students.Count; i++)
            {
                if (university.Students[i].Username == username && university.Students[i].Password == password)
                {
                    return university.Students[i];
                }
            }
            return null;
        }
    }
}
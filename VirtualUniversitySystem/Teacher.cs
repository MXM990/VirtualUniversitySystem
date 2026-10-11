namespace VirtualUniversitySystem
{
    public class Teacher
    {
        public string Username;
        public string Password;
        public string FullName;

        public Teacher(string u, string p, string name)
        {
            Username = u;
            Password = p;
            FullName = name;
        }
    }
}
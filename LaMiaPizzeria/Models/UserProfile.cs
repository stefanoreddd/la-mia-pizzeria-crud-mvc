namespace LaMiaPizzeria.Models
{
    public class UserProfile
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public UserProfile(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}

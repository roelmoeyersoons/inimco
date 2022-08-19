namespace Backend.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Skill> Skills { get; set; }

        public IEnumerable<ISocialAccount> SocialAccounts { get; set; }
    }
}
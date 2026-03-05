namespace ContantManager.Models.Models
{
    public enum ContactCategory
    {
        Private,
        Business,
        Family
    }

    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ContactCategory Category { get; set; }
        public string AvatarPath { get; set; }

        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}

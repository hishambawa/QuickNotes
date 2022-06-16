namespace QuickNotes.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public User(string Username)
        {
            this.Username = Username;
            this.Notes = new HashSet<Note>();
        }

    }
}


namespace QuickNotes.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public virtual List<Note> Notes { get; set; }

        public User(int UserId, string Username)
        {
            this.UserId = UserId;
            this.Username = Username;
        }

    }
}


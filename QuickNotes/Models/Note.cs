using Newtonsoft.Json;

namespace QuickNotes.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Note()
        {

        }

        public Note(string Title, string Content)
        {
            this.Title = Title;
            this.Content = Content;
        }

        public Note(string Title, string Content, User User)
        {
            this.Title = Title;
            this.Content = Content;
            this.User = User;
        }
    }
}


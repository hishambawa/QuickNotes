using System;
namespace QuickNotes.DTO
{
    public class NoteDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int NoteId { get; set; }
        public int UserId { get; set; }
    }
}


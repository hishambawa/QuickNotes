using Microsoft.EntityFrameworkCore;
using QuickNotes.DTO;
using QuickNotes.Models;

namespace QuickNotes.Services
{
    public class NoteService : INoteService
    {
        private readonly NotesDbContext _context;

        public NoteService(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<Response> CreateNote(NoteDTO Note)
        {
            User User = _context.Users.Find(Note.UserId);

            if (User == null)
            {
                return new Response(0, "User not found");
            }

            Note NewNote = new Note(Note.Title, Note.Content, User);

            _context.Add(NewNote);
            await _context.SaveChangesAsync();

            return new Response(1, "Note was created");
        }

        public async Task<Response> GetNotes(int UserId)
        {
            List<Note> Notes = await _context.Notes.Where(note => note.UserId == UserId).ToListAsync();

            return new Response(1, Notes, "Notes were retrieved");
        }

        public async Task<Response> UpdateNote(NoteDTO Note)
        {
            Note ExistingNote = _context.Notes.Find(Note.NoteId);

            if (ExistingNote == null)
            {
                return new Response(0, "Note with that ID doesn't exist");
            }

            ExistingNote.Title = Note.Title;
            ExistingNote.Content = Note.Content;

            _context.Update(ExistingNote);
            await _context.SaveChangesAsync();

            return new Response(1, "Note was updated successfully");
        }

        public async Task<Response> DeleteNote(int NoteId)
        {
            Note Note = _context.Notes.Find(NoteId);

            if (Note == null)
            {
                return new Response(0, "Note with that ID doesn't exist");
            }

            _context.Notes.Remove(Note);
            await _context.SaveChangesAsync();

            return new Response(1, "Note was deleted successfully");

        }
    }
}


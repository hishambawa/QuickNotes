using QuickNotes.DTO;

namespace QuickNotes.Services
{
    public interface INoteService
    {
        Task<Response> CreateNote(NoteDTO Note);
        Task<Response> UpdateNote(NoteDTO Note);
        Task<Response> DeleteNote(int NoteId);
        Task<Response> GetNotes(int UserId);
    }
}


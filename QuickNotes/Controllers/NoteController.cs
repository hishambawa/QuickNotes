using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickNotes.DTO;
using QuickNotes.Services;

namespace QuickNotes.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/[controller]")]
    public class NoteController
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public Task<Response> CreateNote(NoteDTO Note)
        {
            return _noteService.CreateNote(Note);
        }

        [HttpGet]
        [Route("{UserId}")]
        public Task<Response> GetNotes(int UserId)
        {
            return _noteService.GetNotes(UserId);
        }

        [HttpPut]
        public Task<Response> UpdateNote(NoteDTO Note)
        {
            return _noteService.UpdateNote(Note);
        }

        [HttpDelete]
        [Route("{NoteId}")]
        public Task<Response> DeleteNote(int NoteId)
        {
            return _noteService.DeleteNote(NoteId);
        }
    }
}


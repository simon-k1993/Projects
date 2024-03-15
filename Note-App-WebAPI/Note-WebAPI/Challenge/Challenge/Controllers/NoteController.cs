using Challenge.Domain.Entities;
using Challenge.DTOs;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Challenge.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly UserManager<AppUser> _userManager;

        public NoteController(INoteService noteService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteToReturnDTO>>> GetAllNotes()
        {
            try
            {
                var notes = await _noteService.GetAllNotes();
                var x = User;
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteToReturnDTO>> GetNoteById(int id)
        {
            try
            {
                var note = await _noteService.GetById(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNote([FromBody] NoteAddDTO addNoteDto)
        {
            try
            {
                await _noteService.AddNote(addNoteDto);
                return Ok("Note added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNote(int id, [FromBody] NoteUpdatedDTO updateNoteDto)
        {
            try
            {
                await _noteService.UpdateNote(id, updateNoteDto);
                return Ok("Note updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            try
            {
                await _noteService.DeleteNote(id);
                return Ok("Note deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<List<NoteToReturnDTO>>> GetAllNotesPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedNotes = await _noteService.GetAllNotesPaged(page, pageSize);
                return Ok(pagedNotes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<NoteToReturnDTO>>> SearchNotes([FromQuery] string searchTerm)
        {
            try
            {
                var searchedNotes = await _noteService.SearchNotes(searchTerm);
                return Ok(searchedNotes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<NoteToReturnDTO>>> FilterNotesByCategory([FromQuery] string category)
        {
            try
            {
                var filteredNotes = await _noteService.FilterNotesByCategory(category);
                return Ok(filteredNotes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
       
    }
}

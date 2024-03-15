using Azure;
using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using Challenge.Domain.Enums;
using Challenge.DTOs;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        public NoteService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task AddNote(NoteAddDTO addNoteDto)
        {
            if (addNoteDto == null)
            {
                throw new Exception("Entity cannot be null");
            }

            var noteToAdd = new Note
            {
                Name = addNoteDto.Name,
                DueDate = addNoteDto.DueDate,
                Description = addNoteDto.Description,
                Status = addNoteDto.Status,
                Category = addNoteDto.Category,
                UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            _unitOfWork.NoteRepository.Add(noteToAdd);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteNote(int id)
        {
            var note = _unitOfWork.NoteRepository.GetById(id);

            if (note == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _unitOfWork.NoteRepository.Delete(note);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<NoteToReturnDTO>> FilterNotesByCategory(string category)
        {
            if (!Enum.TryParse<Category>(category, out var categoryEnum))
            {
                throw new Exception($"Invalid category value: {category}");
            }

            var notes = _unitOfWork.NoteRepository.GetAll()
                .Where(note => note.Category == categoryEnum);

            return notes.Select(note => new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString(),
                Category = note.Category.ToString()
            }).ToList();
        }


        public async Task<List<NoteToReturnDTO>> GetAllNotes()
        {
            var notes = _unitOfWork.NoteRepository.GetAll().Where(x => x.UserId == _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return notes.Select(note => new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString(),
                Category = note.Category.ToString()
            }).ToList();
        }

        public async Task<List<NoteToReturnDTO>> GetAllNotesPaged(int page, int pageSize)
        {
            var notes = _unitOfWork.NoteRepository.GetAll();
            var pagedNotes = notes.Skip((page - 1) * pageSize).Take(pageSize);

            return pagedNotes.Select(note => new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString(),
                Category = note.Category.ToString()
            }).ToList();
        }

        public async Task<NoteToReturnDTO> GetById(int id)
        {
            var note = _unitOfWork.NoteRepository.GetById(id);

            if (note == null)
            {
                throw new Exception("Entity cannot be null");
            }

            return new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString(),
                Category = note.Category.ToString()
            };
        }

        public async Task<List<NoteToReturnDTO>> SearchNotes(string searchTerm)
        {
            var notes = _unitOfWork.NoteRepository.GetAll()
                .Where(note => note.Name.Contains(searchTerm) ||
                               note.Description.Contains(searchTerm) ||
                               note.Status.ToString().Contains(searchTerm) ||
                               note.Category.ToString().Contains(searchTerm));

            return notes.Select(note => new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString(),
                Category = note.Category.ToString()
            }).ToList();
        }

        public async Task UpdateNote(int id, NoteUpdatedDTO updateNoteDto)
        {
            if (updateNoteDto == null)
            {
                throw new ArgumentNullException(nameof(updateNoteDto));
            }

            var existingNote = _unitOfWork.NoteRepository.GetById(id);

            if (existingNote == null)
            {
                throw new Exception("Entity cannot be null");
            }

            existingNote.Name = updateNoteDto.Name;
            existingNote.DueDate = updateNoteDto.DueDate;
            existingNote.Description = updateNoteDto.Description;
            existingNote.Status = updateNoteDto.Status;
            existingNote.Category = updateNoteDto.Category;

            _unitOfWork.NoteRepository.Update(existingNote);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}





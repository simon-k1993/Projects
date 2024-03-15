//using Challenge.DataAccess.Interfaces;
//using Challenge.Domain.Entities;
//using Challenge.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Challenge.DataAccess.Implementations
//{
//    public class NoteRepository : INoteRepository<Note>
//    {
//        private readonly AppDbContext _appDbContext;

//        public NoteRepository(AppDbContext appDbContext)
//        {
//            _appDbContext = appDbContext;
//        }

//        public void Add(Note entity)
//        {
//            if (entity == null)
//            {
//                throw new Exception("Entity cannot be null");
//            }

//            _appDbContext.Notes.Add(entity);
//        }

//        public void Delete(Note entity)
//        {
//            if (entity == null)
//            {
//                throw new Exception("Entity cannot be null");
//            }

//            _appDbContext.Notes.Remove(entity);
//        }

//        public List<Note> GetAll()
//        {
//            return _appDbContext.Notes.ToList();
//        }

//        public Note GetById(int id)
//        {
//            return _appDbContext.Notes.Find(id);
//        }

//        public void Update(Note entity)
//        {
//            if (entity == null)
//            {
//                throw new Exception("Entity cannot be null");
//            }

//            _appDbContext.Notes.Update(entity);
//        }

//        public void UpdateNote(int id, NoteUpdatedDTO updateNoteDto)
//        {
//            if (updateNoteDto == null)
//            {
//                throw new ArgumentNullException(nameof(updateNoteDto));
//            }

//            var existingNote = _appDbContext.Notes.Find(id);

//            if (existingNote == null)
//            {
//                throw new Exception("Entity cannot be null");
//            }

//            existingNote.Name = updateNoteDto.Name;
//            existingNote.DueDate = updateNoteDto.DueDate;
//            existingNote.Description = updateNoteDto.Description;
//            existingNote.Status = updateNoteDto.Status;
//        }
//    }
//}

using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using Challenge.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.DataAccess.Implementations
{
    public class NoteRepository : INoteRepository<Note>
    {
        private readonly AppDbContext _appDbContext;

        public NoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Note entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _appDbContext.Notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _appDbContext.Notes.Remove(entity);
        }

        public List<Note> GetAll()
        {
            return _appDbContext.Notes.ToList();
        }

        public Note GetById(int id)
        {
            return _appDbContext.Notes.Find(id);
        }

        public void Update(Note entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _appDbContext.Notes.Update(entity);
        }

        public void UpdateNote(int id, NoteUpdatedDTO updateNoteDto)
        {
            if (updateNoteDto == null)
            {
                throw new ArgumentNullException(nameof(updateNoteDto));
            }

            var existingNote = _appDbContext.Notes.Find(id);

            if (existingNote == null)
            {
                throw new Exception("Entity cannot be null");
            }

            existingNote.Name = updateNoteDto.Name;
            existingNote.DueDate = updateNoteDto.DueDate;
            existingNote.Description = updateNoteDto.Description;
            existingNote.Status = updateNoteDto.Status;
        }
    }
}

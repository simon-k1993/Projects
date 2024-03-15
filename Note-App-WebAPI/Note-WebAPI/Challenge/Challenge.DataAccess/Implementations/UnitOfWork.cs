//using Challenge.DataAccess.Interfaces;
//using Challenge.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Challenge.DataAccess.Implementations
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly AppDbContext _context;
//        private INoteRepository<Note> _noteRepository;

//        public UnitOfWork(AppDbContext context)
//        {
//            _context = context;
//        }

//        public INoteRepository<Note> NoteRepository
//        {
//            get { return _noteRepository ??= new NoteRepository(_context); }
//        }

//        public async Task<int> SaveChangesAsync()
//        {
//            return await _context.SaveChangesAsync();
//        }

//        public void Dispose()
//        {
//            _context.Dispose();
//        }
//    }
//}


using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private INoteRepository<Note> _noteRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public INoteRepository<Note> NoteRepository
        {
            get { return _noteRepository ??= new NoteRepository(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


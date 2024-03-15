using Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INoteRepository<Note> NoteRepository { get; }
        Task<int> SaveChangesAsync();
    }
}

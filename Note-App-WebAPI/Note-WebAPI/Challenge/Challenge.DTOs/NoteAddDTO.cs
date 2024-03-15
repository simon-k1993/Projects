using Challenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.DTOs
{
    public class NoteAddDTO
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
    }
}

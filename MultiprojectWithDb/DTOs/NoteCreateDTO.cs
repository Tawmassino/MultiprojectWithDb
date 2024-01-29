using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class NoteCreateDTO
    {

        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }

        [ForeignKey("NoteAuthor")]
        public string Author { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] Picture { get; set; }

    }
}

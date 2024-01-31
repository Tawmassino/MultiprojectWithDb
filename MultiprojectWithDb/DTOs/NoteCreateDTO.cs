using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class NoteCreateDTO
    {



        [Required][StringLength(20)] public string Title { get; set; }


        [StringLength(100, MinimumLength = 1)] public string? Description { get; set; }

        [Required] public string Category { get; set; }


        [ForeignKey("NoteAuthor")] public string Author { get; set; }


        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }


        public byte[] Picture { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.DataAccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }

        [ForeignKey("UserNotes")]
        public List<Note> Notes { get; set; }

    }
}

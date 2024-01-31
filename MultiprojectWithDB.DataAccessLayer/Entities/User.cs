using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiprojectWithDB.DataAccessLayer.Entities
{
    public class User
    {
        //keisti
        //validatoraii tik DTO
        // ir tiktai POST (create) arba PUT (update)


        public int Id { get; set; }
        [Required][StringLength(30, MinimumLength = 3)] public string Username { get; set; }
        [EmailAddress] public string? Email { get; set; }



        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }


        public string Role { get; set; }

        //nereikia FK sitam
        public List<Note> Notes { get; set; }

    }
}

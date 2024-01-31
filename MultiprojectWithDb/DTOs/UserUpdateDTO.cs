using System.ComponentModel.DataAnnotations;

namespace MultiprojectWithDb.API.DTOs
{
    public class UserUpdateDTO
    {
        //public int Id { get; set; } - ID tik per getDTO
        [Required][StringLength(30, MinimumLength = 3)] public string Username { get; set; }
        [EmailAddress] public string? Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

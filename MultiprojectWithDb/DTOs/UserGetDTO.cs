using MultiprojectWithDB.DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace MultiprojectWithDb.API.DTOs
{
    public class UserGetDTO
    {
        //getDTO validatoriu nereikia

        public int Id { get; set; } //id per DTO gali buti tik get metode
        public string Username { get; set; }
        [EmailAddress] public string? Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Note>? Notes { get; set; }
    }
}

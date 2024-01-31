using MultiprojectWithDB.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class UserCreateDTO
    {
        [Required][StringLength(30, MinimumLength = 3)] public string Username { get; set; }
        [EmailAddress] public string? Email { get; set; }
        public string Password { get; set; }

    }
}

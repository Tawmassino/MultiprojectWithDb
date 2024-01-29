using MultiprojectWithDb.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class LoginResponseDTO : UserResponseDto
    {
        public string Token { get; set; }

        public LoginResponseDTO(bool isSuccess, string message, string token) : base(isSuccess, message)
        {
            Token = token;
        }

    }
}

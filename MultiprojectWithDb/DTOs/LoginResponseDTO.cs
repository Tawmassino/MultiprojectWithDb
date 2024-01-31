using MultiprojectWithDb.DTOs;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class LoginResponseDTO : UserResponse
    {
        public string Token { get; set; }

        public LoginResponseDTO(bool isSuccess, string message, string token) : base(isSuccess, message)
        {
            Token = token;
        }

    }
}

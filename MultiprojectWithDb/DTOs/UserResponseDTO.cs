namespace MultiprojectWithDb.DTOs
{
    public class UserResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public UserResponseDTO(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public UserResponseDTO(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}

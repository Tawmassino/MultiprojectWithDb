namespace MultiprojectWithDb.DTOs
{
    public class UserResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public UserResponseDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public UserResponseDto(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}

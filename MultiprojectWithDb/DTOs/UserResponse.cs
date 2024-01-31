namespace MultiprojectWithDb.DTOs
{
    public class UserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public UserResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public UserResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}

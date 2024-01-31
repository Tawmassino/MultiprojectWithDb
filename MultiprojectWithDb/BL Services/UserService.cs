using MultiprojectWithDb.DTOs;
using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MultiprojectWithDB.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersDBRepository _userDBRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUsersDBRepository userRepository,
            IHttpContextAccessor contextAccessor)
        {
            _userDBRepository = userRepository;
            _httpContextAccessor = contextAccessor;

        }

        // ==================== methods ====================


        public UserResponse Login(string username, string password, out string role)
        {
            var user = _userDBRepository.GetUserByUsername(username);
            role = user.Role;
            if (user == null)
            {
                return new UserResponse(false, "Username or password does not match");
            };

            if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
            {
                return new UserResponse(false, "Username or password does not match");
            }

            return new UserResponse(true, "User logged in");
        }


        public UserResponse Register(string username, string password)//nera parametre emaill net
        {
            var user = _userDBRepository.GetUserByUsername(username);
            if (user is not null)
            {
                return new UserResponse(false, "User already exists");
            }

            user = CreateUser(username, password);
            _userDBRepository.SaveUser(user);
            return new UserResponse(true);
        }

        private User CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Username = username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "User",
            };

            return user;
        }

        public int GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //per program cs: builder.Services.AddHttpContextAccessor();
            return int.Parse(userId);
        }


        // ==================== password hash verification ====================
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }

    }
}

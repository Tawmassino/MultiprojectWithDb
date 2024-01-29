using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDb.DTOs;

namespace MultiprojectWithDB.BusinessLogic.Services
{
    public class UserService : IUserService//kelt i API
    {
        private readonly IUsersDBRepository _userDBRepository;

        public UserService(IUsersDBRepository userRepository)
        {
            _userDBRepository = userRepository;
        }

        // ==================== methods ====================


        public UserResponseDTO Login(string username, string password, out string role)
        {
            var user = _userDBRepository.GetUser(username);
            role = user.Role;
            if (user == null)
            {
                return new UserResponseDTO(false, "Username or password does not match");
            };

            if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
            {
                return new UserResponseDTO(false, "Username or password does not match");
            }

            return new UserResponseDTO(true, "User logged in");
        }


        public UserResponseDTO Register(string username, string password)
        {
            var user = _userDBRepository.GetUser(username);
            if (user is not null)
            {
                return new UserResponseDTO(false, "User already exists");
            }

            user = CreateUser(username, password);
            _userDBRepository.SaveUser(user);
            return new UserResponseDTO(true);
        }

        private User CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Id = Convert.ToInt32(Guid.NewGuid()),
                Username = username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "User"
            };

            return user;
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

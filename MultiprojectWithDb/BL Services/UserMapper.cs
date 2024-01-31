using MultiprojectWithDb.API.DTOs;
using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.BusinessLogic.BL_Services
{
    public class UserMapper : IUserMapper //sito maperio GAL nereikia, jei userService metodai parametruose nepriima  USER klases
    {
        /// <summary>
        /// dto -> model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public User Map(UserCreateDTO dto)
        {

            return new User
            {
                Username = dto.Username,
                Email = dto.Email,
                // Password = dto.Password,
            };
        }

        /// <summary>
        /// dto -> model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public User Map(UserUpdateDTO dto)
        {
            var entity = new User
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
            };
            return entity;
        }

        /// <summary>
        /// model -> dto
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserGetDTO Map(User user)
        {
            var entity = new UserGetDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                //Password = user.Password, <- mes DTO nesiunciame passwordo, tai slapta info
                Role = user.Role,
            };
            return entity;
        }
    }
}

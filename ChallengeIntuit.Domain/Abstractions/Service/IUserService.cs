using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeIntuit.DAL.DTOs.Request;
using ChallengeIntuit.DAL.DTOs.Response;
using ChallengeIntuit.Domain.DTOs.Request;
using ChallengeIntuit.Domain.Models;

namespace ChallengeIntuit.Domain.Abstractions.Service
{
    public interface IUserService
    {
        Task<PaginationDTO<User>> GetAllUsers(FilterDTO filterDTO);
        Task<User> GetUserById(int id);
        Task<List<User>> SearchUsers(string name);
        Task<User> CreateUser(UserCreateDTO user);
        Task<bool> UpdateUser(UserUpdateDTO user);
        Task<bool> DeleteUser(int userId);
    }
}

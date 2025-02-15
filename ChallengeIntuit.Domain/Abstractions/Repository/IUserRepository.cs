using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeIntuit.Domain.Models;
using ChallengeIntuit.DAL.DTOs.Request;
using ChallengeIntuit.DAL.DTOs.Response;

namespace ChallengeIntuit.DAL.Repository
{
    public interface IUserRepository
    {
        Task<PaginationDTO<User>> GetAllUsers(FilterDTO filterDTO);
        Task<User> GetUserById(int id);
        Task<List<User>> SearchUsers(string name);
        Task<User> AddUser(User user);
        Task<bool> UpdateUser(User user);
    }
}

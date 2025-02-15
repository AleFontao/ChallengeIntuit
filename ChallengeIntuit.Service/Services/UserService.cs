using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChallengeIntuit.DAL.DTOs.Request;
using ChallengeIntuit.DAL.DTOs.Response;
using ChallengeIntuit.DAL.Repository;
using ChallengeIntuit.Domain.Abstractions.Service;
using ChallengeIntuit.Domain.DTOs.Request;
using ChallengeIntuit.Domain.Models;

namespace ChallengeIntuit.Service.Services
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PaginationDTO<User>> GetAllUsers(FilterDTO filterDTO)
        {
            return await _userRepository.GetAllUsers(filterDTO);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<List<User>> SearchUsers(string name)
        {
            return await _userRepository.SearchUsers(name);
        }

        public async Task<User> CreateUser(UserCreateDTO userCreateDTO)
        {
            var userToCreate = _mapper.Map<User>(userCreateDTO);
            return await _userRepository.AddUser(userToCreate);
        }

        public async Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            var userToUpdate = await GetUserById(userUpdateDTO.Id);

            if (userToUpdate == null)
            {
                return false; 
            }

            _mapper.Map(userUpdateDTO, userToUpdate);
            return await _userRepository.UpdateUser(userToUpdate);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var userToDelete = await GetUserById(userId);

            if (userToDelete == null)
            {
                return false;
            }

            userToDelete.IsDeleted = true;
            return await _userRepository.UpdateUser(userToDelete);
        }

    }
}

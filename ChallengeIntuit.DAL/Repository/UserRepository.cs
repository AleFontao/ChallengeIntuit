using System.Linq.Expressions;
using ChallengeIntuit.DAL.DTOs.Request;
using ChallengeIntuit.DAL.DTOs.Response;
using ChallengeIntuit.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ChallengeIntuit.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ChallengeIntuitContext _context;
        private const string Collation = "SQL_Latin1_General_CP1_CI_AI";

        public UserRepository(ChallengeIntuitContext context)
        {
            _context = context;
        }

        public async Task<PaginationDTO<User>> GetAllUsers(FilterDTO filterDTO)
        {
            var query = _context.Users.AsQueryable();
            if (!filterDTO.IncludeInactive)
            {
                query = query.Where(x => !x.IsDeleted);
            }

            if (!string.IsNullOrEmpty(filterDTO.SearchValue))
            {
                query = query.Where(x => EF.Functions.Collate((x.FirstName + " " + x.LastName).ToLower(), Collation)
                  .Contains(filterDTO.SearchValue.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterDTO.ColumnFilter) && filterDTO.SortBy.HasValue)
            {
                query = filterDTO.SortBy == SORTBY.DESC
                    ? query.OrderByDescending(x => EF.Property<object>(x, filterDTO.ColumnFilter))
                    : query.OrderBy(x => EF.Property<object>(x, filterDTO.ColumnFilter));
            }

            var totalItems = await query.CountAsync();

            if (filterDTO.Skip.HasValue)
            {
                query = query.Skip(filterDTO.Skip.Value);
            }

            if (filterDTO.Limit.HasValue)
            {
                query = query.Take(filterDTO.Limit.Value);
            }

            var users = await query.ToListAsync();

            return new PaginationDTO<User>
            {
                TotalItems = totalItems,
                Items = users
            };
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> SearchUsers(string name)
        {
            return await _context.Users.Where(x => EF.Functions.Collate((x.FirstName + " " + x.LastName).ToLower(), Collation)
                  .Contains(name.ToLower())).ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {          
            try
            {
                _context.Users.Update(user);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

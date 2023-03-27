using SpecificationPatternAPI.Domain.Contracts.Repositories;
using SpecificationPatternAPI.Domain.Contracts.Services;
using SpecificationPatternAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> FindBy(Expression<Func<User, bool>> predicate)
        {
            return await _userRepository.FindBy(predicate);
        }

        public async Task<User> Single(Expression<Func<User, bool>> predicate)
        {
            return await _userRepository.Single(predicate);
        }
    }
}

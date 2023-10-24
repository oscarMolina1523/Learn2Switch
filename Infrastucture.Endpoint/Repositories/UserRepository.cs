using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces;

namespace Infrastucture.Endpoint.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

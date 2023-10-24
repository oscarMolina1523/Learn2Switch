using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;

namespace Domain.Endpoint.Services
{
    public class UserServices : IUserServices
    {
        public User createUser(UserDTO newUserDTO)
        {
            throw new NotImplementedException();
        }

        public User FilterUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Get()
        {
            throw new NotImplementedException();
        }
    }
}

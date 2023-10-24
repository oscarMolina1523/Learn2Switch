using Domain.Endpoint.Entities;

namespace Domain.Endpoint.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(Guid id);

        void Create(User user);
    }
}

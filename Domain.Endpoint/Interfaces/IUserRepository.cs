using Domain.Endpoint.Entities;

namespace Domain.Endpoint.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        User GetById(Guid id);

        void Create(User user);
    }
}

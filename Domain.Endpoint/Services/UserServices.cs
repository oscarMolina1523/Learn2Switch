using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces;

namespace Domain.Endpoint.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;       
        }
        public User createUser(UserDTO newUserDTO)
        {
            User nuevoUsuario = new User()
            {
                Id = Guid.NewGuid(),
                UserName = newUserDTO.UserName,
                UserEmail=newUserDTO.UserEmail,
                UserPassword=newUserDTO.UserPassword,
            };
           _userRepository.Create(nuevoUsuario);
           return nuevoUsuario;
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

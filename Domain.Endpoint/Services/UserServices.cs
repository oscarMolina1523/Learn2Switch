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
            ServiceEncryptDecrypt enc = new ServiceEncryptDecrypt();
            string password= enc.Encrypt(newUserDTO.UserPassword);

            User nuevoUsuario = new User()
            {
                Id = Guid.NewGuid(),
                UserName = newUserDTO.UserName,
                UserEmail=newUserDTO.UserEmail,
                UserPassword=password,
            };
           _userRepository.Create(nuevoUsuario);
           return nuevoUsuario;
        }

        public User FilterUser(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public Task<List<User>> Get()
        {
            return _userRepository.GetAll();
        }
    }
}

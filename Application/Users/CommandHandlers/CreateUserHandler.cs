using Application.Interfaces;
using Application.Users.Commands;
using Domain.Models;
using MediatR;

namespace Application.Users.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Name = request.Name
            };

            return await _userRepository.CreateUser(newUser);
        }
    }
}

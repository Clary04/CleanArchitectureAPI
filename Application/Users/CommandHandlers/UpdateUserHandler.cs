using Application.Interfaces;
using Application.Users.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.CommandHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            if (request.User == null) return new User();

            var user = await _userRepository.UpdateUser(request.User);
            return user;
        }
    }
}

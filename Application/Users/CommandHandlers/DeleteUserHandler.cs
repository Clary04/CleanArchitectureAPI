using Application.Interfaces;
using Application.Users.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(request.UserId);
            return Unit.Value;
        }
    }
}

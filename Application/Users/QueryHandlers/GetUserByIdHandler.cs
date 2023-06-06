using Application.Interfaces;
using Application.Users.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.QueryHandlers
{
    internal class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.UserId);
        }
    }
}

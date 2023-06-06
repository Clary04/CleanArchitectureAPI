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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, ICollection<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers();
        }
    }
}

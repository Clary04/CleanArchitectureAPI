using Domain.Models;
using MediatR;

namespace Application.Users.Commands
{
    public class CreateUser : IRequest<User>
    {
        public string ?Name { get; set; }
    }
}

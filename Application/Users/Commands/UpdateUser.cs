﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class UpdateUser : IRequest<User>
    {
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

﻿using Domain.Models;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetAllUsers : IRequest<ICollection<User>>
    {
    }
}

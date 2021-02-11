using Application.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries
{
    public class GetUserDetailsRequest: IRequest<GetUserDetailsResponse>
    {
    }
}

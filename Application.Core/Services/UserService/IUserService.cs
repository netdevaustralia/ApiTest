using Application.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Services.UserService
{
    public interface IUserService
    {
        Task<GetUserDetailsResponse> GetAsync();
        
    }
}

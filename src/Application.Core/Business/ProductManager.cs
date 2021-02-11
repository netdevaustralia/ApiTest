using Application.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Business
{
    public class ProductManager : IProductManager
    {
        public Task<GetUserDetailsResponse> GetUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}

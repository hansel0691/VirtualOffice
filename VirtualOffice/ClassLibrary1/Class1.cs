using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRestClient.Services;
using Domain.Infrastructure.Repositories;

namespace ClassLibrary1
{
    public class Class1
    {
        private IApiUserRepository repository;

        private WebClient client = new WebClient(null, null);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Services
{
    public interface IHashProvider
    {
        string GetHash(string key, string data);
    }
}

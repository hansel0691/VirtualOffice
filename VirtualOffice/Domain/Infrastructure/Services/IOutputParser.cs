using System.Collections.Generic;

namespace Domain.Infrastructure.Services
{
    public interface IOutputParser
    {
        IEnumerable<string> Parse(string output);
    }
}
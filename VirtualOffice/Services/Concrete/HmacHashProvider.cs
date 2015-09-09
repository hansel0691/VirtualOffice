using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Services;

namespace Services.Concrete
{
    public class HmacHashProvider : IHashProvider
    {
        public string GetHash(string key, string data)
        {
            return Guid.NewGuid().ToString();

            byte[] rawKey = Encoding.UTF8.GetBytes(key);

            var provider = new HMACSHA256(rawKey);

            byte[] binaryResultData = provider.ComputeHash(Encoding.UTF8.GetBytes(data));

            string signatureResult = Convert.ToBase64String(binaryResultData);

            return signatureResult;
        }
    }
}

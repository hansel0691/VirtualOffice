using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRestClient.Models;

namespace ApiRestClient.Infrastructure
{
    public interface IWebClient
    {
        T Execute<T>(IEnumerable<KeyValuePair<string, object>> requestParams, string key, string secret, RequestInfo requestInfo) where T : new();

        T Execute<T>(object requestParamsObj, string key, string secret, RequestInfo requestInfo) where T : new();

        TResult Execute<TResult>(string json, string key, string secret, RequestInfo requestInfo) where TResult : new();

        TResult Execute<TResult>(string key, string secret, RequestInfo requestInfo) where TResult : new();
    }
}

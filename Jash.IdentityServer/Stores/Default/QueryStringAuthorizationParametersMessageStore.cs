


using System.Collections.Generic;
using System.Threading.Tasks;
using Jash.IdentityServer.Models;
using Jash.IdentityServer.Extensions;

namespace Jash.IdentityServer.Stores;

// internal just for testing
internal class QueryStringAuthorizationParametersMessageStore : IAuthorizationParametersMessageStore
{
    public Task<string> WriteAsync(Message<IDictionary<string, string[]>> message)
    {
        var queryString = message.Data.FromFullDictionary().ToQueryString();
        return Task.FromResult(queryString);
    }

    public Task<Message<IDictionary<string, string[]>>> ReadAsync(string id)
    {
        var values = id.ReadQueryStringAsNameValueCollection();
        var msg = new Message<IDictionary<string, string[]>>(values.ToFullDictionary());
        return Task.FromResult(msg);
    }

    public Task DeleteAsync(string id)
    {
        return Task.CompletedTask;
    }
}
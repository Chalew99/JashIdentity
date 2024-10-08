 
 


using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

#pragma warning disable 1591

namespace Jash.IdentityServer.Extensions;

public static class IReadableStringCollectionExtensions
{
    [DebuggerStepThrough]
    public static NameValueCollection AsNameValueCollection(this IEnumerable<KeyValuePair<string, StringValues>> collection)
    {
        var nv = new NameValueCollection();

        foreach (var field in collection)
        {
            foreach (var val in field.Value)
            {
                // special check for some Azure product: https://github.com/JashSoftware/Support/issues/48
                if (!String.IsNullOrWhiteSpace(val))
                {
                    nv.Add(field.Key, val);
                }
            }
        }

        return nv;
    }

    [DebuggerStepThrough]
    public static NameValueCollection AsNameValueCollection(this IDictionary<string, StringValues> collection)
    {
        var nv = new NameValueCollection();

        foreach (var field in collection)
        {
            foreach (var item in field.Value)
            {
                // special check for some Azure product: https://github.com/JashSoftware/Support/issues/48
                if (!String.IsNullOrWhiteSpace(item))
                {
                    nv.Add(field.Key, item);
                }
            }
        }

        return nv;
    }
}
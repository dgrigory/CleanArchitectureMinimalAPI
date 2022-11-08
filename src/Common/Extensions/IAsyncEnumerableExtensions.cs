using System.Runtime.CompilerServices;
using Common.Interfaces;

namespace Common.Extensions;
public static class IAsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<T> FilterRemote<T>(this IAsyncEnumerable<T> enumerable,
        IRemoteFunctionDiscovery functionDiscovery,
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        var remoteFunctions = await functionDiscovery.GetRemoteFilters<T>();

        await foreach (var x in enumerable)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            bool passed = true;
            foreach (var func in remoteFunctions)
            {
                if (!await func.Apply(x, cancellationToken))
                {
                    passed = false;
                    break;
                }
            }
            if (passed)
            {
                yield return x;
            }
        }

        yield break;
    }

    public static async IAsyncEnumerable<T> TransformRemote<T>(this IAsyncEnumerable<T> enumerable,
        IRemoteFunctionDiscovery functionDiscovery,
        [EnumeratorCancellation] CancellationToken cancellationToken
        )
    {
        var remoteFunctions = await functionDiscovery.GetRemoteTransforms<T>();

        await foreach (var x in enumerable)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            T retObj = x;
            foreach (var func in remoteFunctions)
            {
                retObj = await func.Apply(retObj, cancellationToken);
            }

            yield return retObj;
        }

        yield break;
    }
}

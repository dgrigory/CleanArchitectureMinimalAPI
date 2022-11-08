namespace Common.Interfaces;

public class DummyFunctionDiscovery : IRemoteFunctionDiscovery
{
    public Task<List<IRemoteFilter<T>>> GetRemoteFilters<T>()
    {
        return Task.FromResult(new List<IRemoteFilter<T>>());
    }

    public Task<List<IRemoteTransform<T>>> GetRemoteTransforms<T>()
    {
        return Task.FromResult(new List<IRemoteTransform<T>>());
    }
}
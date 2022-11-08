namespace Common.Interfaces;
public interface IRemoteFunctionDiscovery
{
    Task<List<IRemoteFilter<T>>> GetRemoteFilters<T>();

    Task<List<IRemoteTransform<T>>> GetRemoteTransforms<T>();
}
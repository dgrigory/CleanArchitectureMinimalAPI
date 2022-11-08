namespace Common.Interfaces;
public interface IRemoteFunction<T, R>
{
    ValueTask<R> Apply(T t, CancellationToken cancellationToken);
}
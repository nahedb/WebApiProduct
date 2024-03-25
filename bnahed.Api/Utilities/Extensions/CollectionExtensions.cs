namespace bnahed.Api.Utilities.Extensions;

public static class CollectionExtensions
{
    public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
    {
        src.ToList().ForEach(action);
    }
}

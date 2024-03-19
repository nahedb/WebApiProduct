using Newtonsoft.Json;

namespace bnahed.Api.Utilities.Extensions;
public static class ObjectExtensions
{
    public static string ToJson(this object obj)
        => JsonConvert.SerializeObject(obj, Formatting.Indented);
    
    public static void ExecuteIfTrue<T>(this T obj, Func<T, bool> condition, Action<T> action)
    {
        if (condition(obj))
        {
            action(obj);
        }
    }
    public static void ExecuteIfTrue<T>(this T obj, bool condition, Action<T> action)
    {
        if (condition)
        {
            action(obj);
        }
    }
}


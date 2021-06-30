using System.Collections.Generic;

namespace System.Linq
{
    public static class ForEachLinqExtension
    {
        public static IEnumerable<T> ForEachItem<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source != null && action != null)
            {
                foreach (T element in source)
                {
                    action(element);
                }
            }

            return source;
        }

        public static IList<T> ForEachItem<T>(this IList<T> source, Action<T> action)
        {
            return (IList<T>)((IEnumerable<T>)source).ForEachItem(action);
        }

        public static List<T> ForEachItem<T>(this List<T> source, Action<T> action)
        {
            return (List<T>)((IEnumerable<T>)source).ForEachItem(action);
        }
    }
}
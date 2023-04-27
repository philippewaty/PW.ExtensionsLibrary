using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwExtensionsLibrary
{
  public static class CollectionExtensions
  {
    /// <summary>
    /// Extension that adds an element to a collection only if a given condition is met.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <param name="item"></param>
    /// <url>https://www.extensionmethod.net/csharp/icollection/addif</url>
    public static void AddIf<T>(this ICollection<T> collection, Func<bool> predicate, T item)
    {
      if (predicate.Invoke())
        collection.Add(item);
    }

    /// <summary>
    /// Extension that adds an element to a collection only if a given condition is met.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <param name="item"></param>
    /// <url>https://www.extensionmethod.net/csharp/icollection/addif</url>
    public static void AddIf<T>(this ICollection<T> collection, Func<T, bool> predicate, T item)
    {
      if (predicate.Invoke(item))
        collection.Add(item);
    }
  }
}

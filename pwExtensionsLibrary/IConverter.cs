using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwExtensionsLibrary
{
  /// <summary>
  /// Generic converter interface used to allow extension methods to be applied.
  /// </summary>
  /// <typeparam name = "T"></typeparam>
  public interface IConverter<T>
  {
    /// <summary>
    /// Gets the internal value to be converted.
    /// </summary>
    /// <value>The value.</value>
    T Value { get; }
  }
}

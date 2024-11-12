using System;

namespace Arithmetics.Algorithms.Sorters.External
{
    public interface ISequentialStorageReader<out T> : IDisposable
    {
        T Read();
    }
}
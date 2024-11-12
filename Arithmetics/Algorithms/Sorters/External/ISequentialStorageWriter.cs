using System;

namespace Arithmetics.Algorithms.Sorters.External
{
    public interface ISequentialStorageWriter<in T> : IDisposable
    {
        void Write(T value);
    }
}
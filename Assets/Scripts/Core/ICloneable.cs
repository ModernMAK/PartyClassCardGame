using System;

namespace Core
{
    public interface ICloneable<out T> : ICloneable
    {
        new T Clone();
    }
}
using System;

namespace BeboTools.Utils
{
    public interface IObservable
    { 
        event Action OnChange;
        object Value { get; set; }
        bool HasValue { get; }
    }
    
    public interface IObservable<T> : IObservable
    {
        new T Value { get; set; }
    }
}
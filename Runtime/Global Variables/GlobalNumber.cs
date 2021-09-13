using UnityEngine;

namespace Core.GlobalVariable
{
    /// <summary>
    /// Forced variable "Value to be constrained
    /// </summary>
    /// <typeparam name="T">T must be a number (e.g. int, double)</typeparam>
    public abstract class GlobalNumber<T> : GlobalVariable<T> where T : struct
    {
        [SerializeField] private T min;
        [SerializeField] private T max;

        public new T Value
        {
            get => base.Value;
            set => base.Value = ConstrianValue(value, min, max);
        }

        public abstract T ConstrianValue(T value, T min, T max);
    }
}


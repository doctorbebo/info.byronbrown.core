using UnityEngine;

namespace Core.Global
{
    /// <summary>
    /// Forced variable "Value to be constrained
    /// </summary>
    /// <typeparam name="T">T must be a number (e.g. int, double)</typeparam>
    public abstract class ClampNumber<T> : GlobalVariable<T> where T : struct
    {
        [SerializeField] private T min = default;
        [SerializeField] private T max = default;

        public new T Value
        {
            get => base.Value;
            set => base.Value = ClampValue(value, min, max);
        }

        public virtual T ClampValue(T value, T min, T max)
        {
            throw new System.NotImplementedException();
        }
    }
}


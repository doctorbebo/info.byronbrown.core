using System;
using UnityEngine;

namespace Core.GlobalVariable
{
    public abstract class GlobalVariable<T> : ScriptableObject where T : struct
    {
        [SerializeField] private T startValue = default;

        private Action OnChange;
        private T value;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChange?.Invoke();
            }
        }

        public void AddListener(Action action) => OnChange += action; 
        public void RemoveListener(Action action) => OnChange -= action;
        private void OnEnable()
        {
            value = startValue;
        }

        public override string ToString() => value.ToString();
        public override bool Equals(object other) => other is GlobalVariable<T> variable && variable.value.ToString() == value.ToString();
        public override int GetHashCode() => base.GetHashCode();
    }
}


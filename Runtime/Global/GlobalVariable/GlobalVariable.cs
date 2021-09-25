using System;
using UnityEngine;

namespace Core.Global
{
    public abstract class GlobalVariable : ScriptableObject
    {
        public abstract void AddListener(Action action);
        public abstract void RemoveListener(Action action);
    }

    public abstract class GlobalVariable<T> : GlobalVariable where T : struct
    {
        [SerializeField] private T startValue = default;

        private Action OnChange;
        private T value;

        public virtual T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChange?.Invoke();
            }
        }

        public override void AddListener(Action action) => OnChange += action; 
        public override void RemoveListener(Action action) => OnChange -= action;
        public override string ToString() => value.ToString();
        public override bool Equals(object other) => other is GlobalVariable<T> variable && variable.value.ToString() == value.ToString();
        public override int GetHashCode() => base.GetHashCode();

        private void OnEnable()
        {
            value = startValue;
        }

    }
}


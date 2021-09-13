using System;
using UnityEngine;

namespace Core.GlobalVariable
{
    public abstract class GlobalVariable<T> : ScriptableObject where T : struct
    {
        [SerializeField] private T startValue;

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
    }
}

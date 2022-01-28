using System;

namespace BeboTools
{
    public class ObservableObject<T>
    {
        private T value;

        public bool HasOnChangeSubscribers => OnChange?.GetInvocationList().Length > 0;

        public event Action<T> OnChange;
        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChange?.Invoke(value);
            }
        }
    }
}

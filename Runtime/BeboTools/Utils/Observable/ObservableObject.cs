using System;

namespace BeboTools.Utils
{
    public abstract class ObservableObject : IObservable
    {
        public event Action OnChange;
        
        private object value;
        public object Value
        {
            get => value;
            set
            {
                this.value = value;
                InvokeOnChange();
            }
        }
        
        public bool HasObservers => OnChange?.GetInvocationList().Length > 0;
        public bool HasValue => Value != default;
        public override string ToString() => Value.ToString();
        protected void InvokeOnChange() => OnChange?.Invoke();
    }
    
    public class ObservableObject<T> : ObservableObject, IObservable<T>
    {
        private T value;
        public new T Value
        {
            get => value;
            set
            {
                this.value = value;
                InvokeOnChange();
            }
        }
    }
}

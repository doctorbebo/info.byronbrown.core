using System;
using System.Collections;
using System.Collections.Generic;

namespace BeboTools.Utils
{
    public class ObservableList<T> : IList<T> where T : IObservable
    {
        public event Action OnChange;
        private void Invoke() => OnChange?.Invoke();
        private readonly List<T> list = new List<T>();
        private object value;

        public void Add(T item)
        {
            if (item != null)
            {
                item.OnChange += Invoke;
            }
            list.Add(item);
            Invoke();
        }

        public void Clear()
        {
            foreach (T observable in list)
            {
                if (observable != null)
                {
                    observable.OnChange -= Invoke;
                }
                list.Clear();
                Invoke();
            }
        }
        
        public void Insert(int index, T item)
        {
            if (item != null)
            {
                item.OnChange += Invoke;
            }
            list.Insert(index, item);
            Invoke();
        }
        
        public bool Remove(T item)
        {
            bool returnVal = list.Remove(item);
            if (item != null && returnVal)
            {
                item.OnChange -= Invoke;
                Invoke();
            }
            return returnVal;
        }

        public void RemoveAt(int index)
        {
            T item = list[index];
            if (item != null)
            {
                item.OnChange -= Invoke;
            }
            list.RemoveAt(index);
        }

        #region Passed Along Functions
        
        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

        public bool Contains(T item) => list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        
        public int Count => list.Count;
        public bool IsReadOnly => ((ICollection<T>) list).IsReadOnly;
        public int IndexOf(T item) => list.IndexOf(item);
        
        
        public T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
        
        #endregion
    }
}
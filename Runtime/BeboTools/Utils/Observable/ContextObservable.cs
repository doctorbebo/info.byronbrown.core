using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BeboTools.Utils
{
    /// <summary>
    /// Context Variable holds an instance of type T the lives within the context of the Object. Wi
    /// </summary>
    /// <typeparam name="T">Type of the instance</typeparam>
    [Serializable]
    public class ContextObservable<T>
    {

        #region Static

        /// <summary>
        /// Assigns an observer to observe when the value changes. Will call the observer immediately if the current value is not equal to the generics default.
        /// Observer will only be invoked if the Object context is valid.
        /// </summary>
        /// <param name="context">Object context this is called</param>
        /// <param name="observer"> Function to call when value changes</param>
        public static void Observe(Object context, Action<T> observer)
        {
            if(!context)
                return;
            
            GetContextObservable(context.GetInstanceID()).AddObserver(observer);
        }

        /// <summary>
        /// Sets the value of the Context Variable and will automatically call each observer. 
        /// </summary>
        /// <param name="context">Object context this is called</param>
        /// <param name="value">New value to assign</param>
        public static void SetValue(Object context, T value)
        {
            if (!context)
                return;
            
            GetContextObservable(context.GetInstanceID()).SetValue(value);
        }
        
        private static Dictionary<int, Dictionary<Type, object>> Dictionary = new Dictionary<int, Dictionary<Type, object>>();
        private static ContextObservable<T> GetContextObservable(int instanceId)
        {
            if (!Dictionary.ContainsKey(instanceId))
            {
                Dictionary.Add(instanceId, new Dictionary<Type, object>());
            }
            Dictionary<Type, object> contextDictionary = Dictionary[instanceId];

            Type t = typeof(T);
            if (!contextDictionary.ContainsKey(t))
            {
                contextDictionary.Add(t, new ContextObservable<T>());
            }
            return (ContextObservable<T>)contextDictionary[t];
        }
        
        #endregion

        #region Instance

        private ContextObservable() { }
        private event Action<T> Observers;
        private T value;
        
        private void AddObserver(Action<T> observe)
        {
            if (observe != null)
            {
                Observers += observe;
                if(!EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    observe(value);
                }
            }
        }
        
        public void SetValue(T value)
        {
            this.value = value;
            Observers?.Invoke(value);
        }
        
        #endregion
    }
}
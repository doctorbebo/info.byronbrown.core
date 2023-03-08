using System.Collections.Generic;
using UnityEngine;

namespace BeboTools.ContextVariables
{
    /// <summary>
    /// Base context Behaviour.
    /// </summary>
    /// <typeparam name="T">Type of the variable within the context</typeparam>
    public abstract class BaseObjectContextVariable<T> where T : class, new()
    {
        protected abstract Dictionary<int, T> StaticContextHolder { get; }
        protected abstract int InstanceId { get; }
        public T Value => StaticContextHolder[InstanceId];

        protected void Init()
        {
            if (!StaticContextHolder.ContainsKey(InstanceId))
            {
                StaticContextHolder.Add(InstanceId, new T());
            }
        }
    }
}
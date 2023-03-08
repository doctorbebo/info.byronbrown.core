using System.Collections.Generic;
using UnityEngine;

namespace BeboTools.ContextVariables
{
    /// <summary>
    /// GameObject context variable. Any MonoBehaviours on the same GameObject will share an instance of the given type
    /// </summary>
    /// <typeparam name="T">Instance Type</typeparam>
    public class GameObjectContextVariable<T> : BaseObjectContextVariable<T> where T : class, new()
    {
        private static readonly Dictionary<int, T> contextHolder = new Dictionary<int, T>();
        protected override Dictionary<int, T> StaticContextHolder => contextHolder;
        protected override int InstanceId { get; }

        public GameObjectContextVariable(GameObject context)
        {
            InstanceId = context.GetInstanceID();
            Init();
        }
    }
}
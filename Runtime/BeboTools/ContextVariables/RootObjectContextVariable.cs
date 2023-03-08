using System.Collections.Generic;
using UnityEngine;

namespace BeboTools.ContextVariables
{
    /// <summary>
    /// Root context variable. Any MonoBehaviours that has the same common GameObject ancestor will share an instance of the given type
    /// </summary>
    /// <typeparam name="T">Instance Type</typeparam>
    public class RootObjectContextVariable<T> : BaseObjectContextVariable<T> where T : class, new()
    {
        private static readonly Dictionary<int, T> contextHolder = new Dictionary<int, T>();
        protected override Dictionary<int, T> StaticContextHolder => contextHolder;
        protected override int InstanceId { get; }
        
        public RootObjectContextVariable(GameObject context)
        {
            InstanceId = context.transform.root.GetInstanceID();
            Init();
        }

    }
}
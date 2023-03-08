using System.Collections.Generic;

namespace BeboTools.ContextVariables
{
    /// <summary>
    /// Global context variable. Any MonoBehaviours will share an instance of the given type
    /// </summary>
    /// <typeparam name="T">Instance Type</typeparam>
    public class GlobalContextVariable<T> : BaseObjectContextVariable<T> where T : class, new()
    {
        private static readonly Dictionary<int, T> contextHolder = new Dictionary<int, T>();
        protected override Dictionary<int, T> StaticContextHolder => contextHolder;
        protected override int InstanceId => 0;

        public GlobalContextVariable()
        {
            Init();   
        }
    }
}
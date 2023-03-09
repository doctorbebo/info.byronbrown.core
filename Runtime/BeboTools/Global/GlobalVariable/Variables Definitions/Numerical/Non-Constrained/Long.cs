using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewLong", menuName = "Global/Variables/UnClamped/Long")]
    public class Long : GlobalVariable<long>
    {
        public static implicit operator long(Long v) => v.Value;
    }
}

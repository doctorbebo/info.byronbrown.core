using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewUUInt", menuName = "Global/Variables/UnClamped/UUInt")]
    public class UInt : GlobalVariable<uint> 
    {
        public static implicit operator uint(UInt v) => v.Value;
    }
}

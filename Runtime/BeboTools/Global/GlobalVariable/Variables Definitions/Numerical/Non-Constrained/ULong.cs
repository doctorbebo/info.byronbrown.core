using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewULong", menuName = "Global/Variables/UnClamped/ULong")]
    public class ULong : GlobalVariable<ulong> 
    {
        public static implicit operator ulong(ULong v) => v.Value;
    }
}
using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewInt", menuName = "Global/Variables/UnClamped/Int")]
    public class Int : GlobalVariable<int>
    {
        public static implicit operator int(Int i) => i.Value;
    }
}

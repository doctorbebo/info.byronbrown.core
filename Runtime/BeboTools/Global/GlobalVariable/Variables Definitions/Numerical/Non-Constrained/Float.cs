using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewFloat", menuName = "Global/Variables/UnClamped/Float")]
    public class Float : GlobalVariable<float>
    {
        public static implicit operator float(Float v) => v.Value;
    }
}

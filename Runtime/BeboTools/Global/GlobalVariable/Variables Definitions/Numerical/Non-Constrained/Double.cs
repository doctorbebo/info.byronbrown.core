using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewDouble", menuName = "Global/Variables/UnClamped/Double")]
    public class Double : GlobalVariable<double>
    {
        public static implicit operator double(Double v) => v.Value;
    }
}

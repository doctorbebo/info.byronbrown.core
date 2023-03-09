using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewConstrainedFloat", menuName = "Global/Variables/Clamped/Float")]
    public sealed class ClampedFloat : ClampNumber<float>
    {
        public static implicit operator float(ClampedFloat v) => v.Value;
        public override float ClampValue(float value, float min, float max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}

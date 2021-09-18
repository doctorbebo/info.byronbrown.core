using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedFloat", menuName = "Global Variables/Clamped/Float")]
    public sealed class ClampedFloat : ClampNumber<float>
    {
        public override float ClampValue(float value, float min, float max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}

using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedInt", menuName = "Global Variables/Clamped/Int")]
    public sealed class ClampedInt : ClampNumber<int>
    {
        public override int ClampValue(int value, int min, int max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}

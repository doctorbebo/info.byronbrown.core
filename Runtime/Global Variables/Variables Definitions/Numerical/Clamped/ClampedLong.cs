using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedLong", menuName = "Global Variables/Clamped/Long")]
    public sealed class ClampedLong : ClampNumber<long>
    {
        public override long ClampValue(long value, long min, long max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}
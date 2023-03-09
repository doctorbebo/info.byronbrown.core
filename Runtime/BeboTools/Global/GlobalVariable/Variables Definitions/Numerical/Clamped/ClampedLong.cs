using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewConstrainedLong", menuName = "Global/Variables/Clamped/Long")]
    public sealed class ClampedLong : ClampNumber<long>
    {
        public static implicit operator long(ClampedLong v) => v.Value;
        public override long ClampValue(long value, long min, long max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}
using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedLong", menuName = "Global Variables/Clamped/Long")]
    public sealed class ConstrainedLong : GlobalNumber<long>
    {
        public override long ConstrianValue(long value, long min, long max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}
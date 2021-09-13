using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedULong", menuName = "Global Variables/Clamped/ULong")]
    public sealed class ConstrainedULong : GlobalNumber<ulong>
    {
        public override ulong ConstrianValue(ulong value, ulong min, ulong max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}


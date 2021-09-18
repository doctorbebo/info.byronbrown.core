using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedDecimal", menuName = "Global Variables/Clamped/Decimal")]
    public sealed class ClampedDecimal : ClampNumber<decimal>
    {
        public override decimal ClampValue(decimal value, decimal min, decimal max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}

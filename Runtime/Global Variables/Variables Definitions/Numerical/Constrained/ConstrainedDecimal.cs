using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedDecimal", menuName = "Global Variables/Clamped/Decimal")]
    public sealed class ConstrainedDecimal : ClampNumber<decimal>
    {
        public override decimal ConstrianValue(decimal value, decimal min, decimal max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}

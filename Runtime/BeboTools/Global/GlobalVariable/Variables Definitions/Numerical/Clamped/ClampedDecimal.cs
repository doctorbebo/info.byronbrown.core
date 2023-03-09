using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewConstrainedDecimal", menuName = "Global/Variables/Clamped/Decimal")]
    public sealed class ClampedDecimal : ClampNumber<decimal>
    {
        public static implicit operator decimal(ClampedDecimal v) => v.Value;
        public override decimal ClampValue(decimal value, decimal min, decimal max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}

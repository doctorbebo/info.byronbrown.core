using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedUInt", menuName = "Global Variables/Clamped/UInt")]
    public sealed class ConstrainedUInt : ClampNumber<uint>
    {
        public override uint ConstrianValue(uint value, uint min, uint max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}

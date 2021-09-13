using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewConstrainedDouble", menuName = "Global Variables/Clamped/Double")]
    public sealed class ConstrainedDouble : GlobalNumber<double>
    {
        public override double ConstrianValue(double value, double min, double max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}


using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewConstrainedDouble", menuName = "Global/Variables/Clamped/Double")]
    public sealed class ClampedDouble : ClampNumber<double>
    {
        public override double ClampValue(double value, double min, double max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }
    }
}


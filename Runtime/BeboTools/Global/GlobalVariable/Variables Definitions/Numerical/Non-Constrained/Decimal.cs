using UnityEngine;

namespace BeboTools.Global
{
    [CreateAssetMenu(fileName = "NewDecimal", menuName = "Global/Variables/UnClamped/Decimal")]
    public class Decimal : GlobalVariable<decimal> 
    {
        public static implicit operator decimal(Decimal v) => v.Value;
    }
}

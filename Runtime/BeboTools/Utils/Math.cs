using UnityEngine;

namespace BeboTools
{
    public static class Math
    {
        
        /// <summary>
        /// Returns a new Vector3 rounded to the closest multiple of the rounding factor.
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="roundingFactor"></param>
        /// <returns></returns>
        public static Vector3 Round(this Vector3 vector3, int roundingFactor = 1)
        {
            return Round(vector3, (float) roundingFactor);
        }
        
        /// <summary>
        /// Returns a new Vector3 rounded to the closest multiple of the rounding factor.
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="roundingFactor"></param>
        /// <returns></returns>
        public static Vector3 Round(this Vector3 vector3, float roundingFactor = 1)
        {
            if (roundingFactor < float.Epsilon)
            {
                return Vector3.zero;
            }
            
            return new Vector3
            (
                Mathf.Round(vector3.x / roundingFactor) * roundingFactor,
                Mathf.Round(vector3.y / roundingFactor) * roundingFactor,
                Mathf.Round(vector3.z / roundingFactor) * roundingFactor
            );
        }
        
        /// <summary>
        /// Returns a new Vector3 rounded down to the closest multiple of the rounding factor.
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="roundingFactor"></param>
        /// <returns></returns>
        public static Vector3 RoundDown(this Vector3 vector3, int roundingFactor = 1)
        {
            return RoundDown(vector3, (float)roundingFactor);
        }
        
        /// <summary>
        /// Returns a new Vector3 rounded down to the closest multiple of the rounding factor.
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="roundingFactor"></param>
        /// <returns></returns>
        public static Vector3 RoundDown(this Vector3 vector3, float roundingFactor = 1)
        {
            if (roundingFactor < float.Epsilon)
            {
                return Vector3.zero;
            }
            
            return new Vector3
            (
                Mathf.Floor(vector3.x / roundingFactor) * roundingFactor,
                Mathf.Floor(vector3.y / roundingFactor) * roundingFactor,
                Mathf.Floor(vector3.z / roundingFactor) * roundingFactor
            );
        }
        
        /// <summary>
        /// Returns a new Vector3 rounded up to the closest multiple of the rounding factor.
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="roundingFactor"></param>
        /// <returns></returns>
        public static Vector3 RoundUp(this Vector3 vector3, int roundingFactor = 1)
        {
            return RoundUp(vector3, (float) roundingFactor);
        }
        
        /// <summary>
        /// Returns a new Vector3 rounded up to the closest multiple of the rounding factor.
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="roundingFactor"></param>
        /// <returns></returns>
        public static Vector3 RoundUp(this Vector3 vector3, float roundingFactor = 1)
        {
            if (roundingFactor < float.Epsilon)
            {
                return Vector3.zero;
            }
            
            return new Vector3
            (
                Mathf.Ceil(vector3.x / roundingFactor) * roundingFactor,
                Mathf.Ceil(vector3.y / roundingFactor) * roundingFactor,
                Mathf.Ceil(vector3.z / roundingFactor) * roundingFactor
            );
        }

        public static Vector3 Flat(this Vector3 vector3) => new Vector3(vector3.x, 0, vector3.z);
        
        public static Vector3Int ToVector3Int(this Vector3 vector3)
        {
            return new Vector3Int
            (
                (int) vector3.x,
                (int) vector3.y,
                (int) vector3.z
            );
        }

        public static bool AllVectorsLessThan(this Vector3 vector3, float value)
        {
            return vector3.x < value && vector3.y < value && vector3.z < value;
        }
    }
}
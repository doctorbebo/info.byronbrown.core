using System;
using System.Collections;
using UnityEngine;

namespace BeboTools.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Returns the next index of the Collection and resets to index 0 if it exceeds Collection's length
        /// </summary>
        /// <param name="currentIndex">current index</param>
        /// <returns></returns>
        public static int NextIndex(this ICollection list, int currentIndex)
        {
            currentIndex++;
            return currentIndex >= list.Count ? 0 : currentIndex;
        }

        /// <summary>
        /// Returns the previous index of the Collection and resets index to length -1 if it falls below 0
        /// </summary>
        /// <param name="currentIndex">current index</param>
        /// <returns></returns>
        public static int PreviousIndex(this ICollection list, int currentIndex)
        {
            currentIndex--;
            return currentIndex < 0 ? list.Count - 1 : currentIndex;
        }


        /// <summary>
        /// Unity friendly null check
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Obsolete("Use if(Unity.Object) instead of this method")]
        public static bool IsNull(this UnityEngine.Object obj)
        {
            return (obj == null || obj.Equals(null));
        }

        /// <summary>
        /// Unity friendly null check
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Obsolete("Use if(Unity.Object) instead of this method")]
        public static bool IsNull(this object obj)
        {
            return (obj == null || obj.Equals(null));
        }

        /// <summary>
        /// returns a new Vector3 with the value of x set to given value
        /// </summary>
        /// <param name="v">Vector3</param>
        /// <param name="x"></param>
        /// <returns>Vector3</returns>
        public static Vector3 SetX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);
        
        /// <summary>
        /// returns a new Vector3 with the value of y set to given value
        /// </summary>
        /// <param name="v">Vector3</param>
        /// <param name="y"></param>
        /// <returns>Vector3</returns>
        public static Vector3 SetY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);
        /// <summary>
        /// returns a new Vector3 with the value of z set to given value
        /// </summary>
        /// <param name="v">Vector3</param>
        /// <param name="y"></param>
        /// <returns>Vector3</returns>
        public static Vector3 SetZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);

        /// <summary>
        /// Returns transform position with y set to 0
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static Vector3 FloorPosition(this Transform tran)
        {
            return new Vector3(tran.position.x, 0, tran.position.z);
        }
    }
}
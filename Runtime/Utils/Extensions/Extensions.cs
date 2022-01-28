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
        public static bool IsNull(this UnityEngine.Object obj)
        {
            return (obj == null || obj.Equals(null));
        }

        /// <summary>
        /// Unity friendly null check
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return (obj == null || obj.Equals(null));
        }


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
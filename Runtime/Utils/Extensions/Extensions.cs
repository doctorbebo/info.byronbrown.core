using System;
using System.Collections;
using System.Collections.Generic;

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
    }
}
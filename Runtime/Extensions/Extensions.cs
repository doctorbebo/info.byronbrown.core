using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Messenger
{
    public static class Extensions
    {
        public static void MessagePlayer(this string message)
        {
            new GlobalMessage(message);
        }

        /// <summary>
        /// Returns the next index of the Collection and resets to index 0 if it exceeds Collection's length
        /// </summary>
        /// <typeparam name="T">Type of IEnumerable</typeparam>
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
        /// <typeparam name="T">Type of IEnumerable</typeparam>
        /// <param name="currentIndex">current index</param>
        /// <returns></returns>
        public static int PreviousIndex(this ICollection list, int currentIndex)
        {
            currentIndex--;
            return currentIndex < 0 ? list.Count - 1 : currentIndex;
        }
    }
}
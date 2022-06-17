using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeboTools.Messenger
{
    public static class Extensions
    {
        public static void MessagePlayer(this string message)
        {
            MessageDisplay.QueueMessage(message);
        }
    }
}

using UnityEngine;

namespace Core.Messenger
{
    public sealed class GlobalMessage
    {
        private readonly string message;
        internal string Message => message;

        internal float Duration;

        public GlobalMessage(string message, float duration = 3f)
        {
            message = message.Trim();

            if (message == string.Empty)
                return;

            this.message = message;
            Duration = duration;
            Messenger.QueueMessage(this);
        }
    }
}

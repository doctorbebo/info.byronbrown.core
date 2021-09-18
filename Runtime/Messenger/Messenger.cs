using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Core.Messenger
{
    public sealed class Messenger : MonoBehaviour
    {
        #region Static Members

        private static GlobalMessage message;
        private static readonly Queue<GlobalMessage> messages = new Queue<GlobalMessage>();
        private static List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();
        private static int count = 0;

        private static void _Update()
        {
            if (message == null)
                return;

            if (message.Duration < 0)
            {
                if (messages.Count > 0)
                {
                    message = messages.Dequeue();
                    WriteDisplays();
                }
                else
                {
                    message = null;
                    EraseDisplays();
                }
            }
            else
            {
                message.Duration -= Time.deltaTime;
            }
        }

        public static void QueueMessage(GlobalMessage globalMessage)
        {
            if (message == null)
            {
                message = globalMessage;
                WriteDisplays();
            }
            else
            {
                messages.Enqueue(globalMessage);
            }
        }

        private static void EraseDisplays()
        {
            foreach (var text in texts)
            {
                text.text = string.Empty;
            }
        }

        private static void WriteDisplays()
        {
            foreach (var text in texts)
            {
                text.text = message.Message;
            }
        }

        #endregion

        #region Members

        private int id;
        [SerializeField] private TextMeshProUGUI text = null;

        private void Awake()
        {
            id = count;
            count++;
            texts.Add(text);
        }

        private void Update()
        {
            if (id == 0)
                _Update();
        }

        #endregion
    }
}

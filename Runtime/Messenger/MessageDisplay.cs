using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Core.Messenger
{
    public sealed class MessageDisplay : MonoBehaviour
    {

        private static float duration  = 3f;
        private static float timer;
        public static float Duration
        {
            get => duration;
            set
            {
                value = Mathf.Abs(value);
                value = Mathf.Clamp(value, 0f, 60f);
                duration = value;
            }
        }

        private static string message;
        private static readonly Queue<string> messages = new Queue<string>();
        private static List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();
        private static int count = 0;

        public static void QueueMessage(string newMessage)
        {
            if (message == null)
            {
                message = newMessage;
                WriteDisplays();
                timer = duration;
            }
            else
            {
                messages.Enqueue(newMessage);
            }
        }

        private static void _Update()
        {
            if (message == null)
                return;

            if (timer < 0)
            {
                if (messages.Count > 0)
                {
                    message = messages.Dequeue();
                    WriteDisplays();
                    timer = duration;
                }
                else
                {
                    message = null;
                    EraseDisplays();
                }
            }
            else
            {
                timer -= Time.deltaTime;
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
            if (texts.Count <= 0)
                Debug.LogError($"No Text Object to write to. Make sure TextMeshProUGui is active in scene and has messenger component attached.");

            foreach (var text in texts)
            {
                text.text = message;
            }
        }


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
    }
}

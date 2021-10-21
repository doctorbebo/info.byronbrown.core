using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Global
{
    [CreateAssetMenu(fileName = "NewGlobalEvent", menuName = "Global/Event")]
    public class GlobalEvent : ScriptableObject
    {
        private List<Action> actionEvents;
        private List<UnityEvent> unityEvents;

        private void OnEnable()
        {
            actionEvents = new List<Action>();
            unityEvents = new List<UnityEvent>();
        }

        public void Add(UnityEvent unityEvent) => unityEvents.Add(unityEvent);
        public void Remove(UnityEvent unityEvent) => unityEvents.Remove(unityEvent);
        public void Add(Action actionEvent) => actionEvents.Add(actionEvent);
        public void Remove(Action actionEvent) => actionEvents.Remove(actionEvent);

        public void InvokeGlobalEvent()
        {
            for (int i = actionEvents.Count - 1; i >= 0; i--)
            {
                actionEvents[i]?.Invoke();
            }

            for (int i = unityEvents.Count - 1; i >= 0; i--)
            {
                unityEvents[i]?.Invoke();
            }
        }
    }
}

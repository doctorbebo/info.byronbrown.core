using UnityEngine;
using UnityEngine.Events;

namespace BeboTools.Global
{
    public class EventInitializer : MonoBehaviour
    {
        [SerializeField] private GlobalEvent globalEvent;
        [SerializeField] private UnityEvent Event;

        private void OnEnable()
        {
            globalEvent.Add(Event);
        }

        private void OnDisable()
        {
            globalEvent.Remove(Event);
        }
    }
}

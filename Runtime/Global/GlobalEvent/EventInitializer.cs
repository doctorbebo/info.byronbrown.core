using UnityEngine;
using UnityEngine.Events;

namespace Core.Global
{
    public class EventInitializer : MonoBehaviour
    {
        [SerializeField] private GlobalEvent globalEvent;
        [SerializeField] private UnityEvent Event;

        private void Start()
        {
            globalEvent.Add(Event);
        }
    }
}

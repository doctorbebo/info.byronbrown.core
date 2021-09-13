using System;
using UnityEngine;

namespace Core.GlobalVariable
{
    [CreateAssetMenu(fileName = "NewString", menuName = "Global Variables/String")]
    public class String : ScriptableObject
    { 
        [SerializeField] private string startValue;

        private Action OnChange;

        private string value;
        public string Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChange?.Invoke();
            }
        }

        public void AddListener(Action action) => OnChange += action;
        public void RemoveListener(Action action) => OnChange -= action;
        private void OnEnable()
        {
            value = startValue;
        }
    }
}

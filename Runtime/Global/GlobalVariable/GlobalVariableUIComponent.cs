using UnityEngine;
using TMPro;

namespace BeboTools.Global
{
    public class GlobalVariableUIComponent: MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] private GlobalVariable variable;
        [SerializeField] private string prestring;
        [SerializeField] private string poststring;

        private void Awake()
        {
            if (text == null)
                text = GetComponent<TextMeshProUGUI>();

            UpdateDisplay();
        }

        private void OnEnable()
        {
            variable.AddListener(UpdateDisplay);
        }

        private void OnDisable()
        {
            variable.RemoveListener(UpdateDisplay);
        }

        private void UpdateDisplay()
        {
            text.text = $"{prestring} {variable} {poststring}";
        }
    }
}

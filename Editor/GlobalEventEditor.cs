using UnityEngine;
using UnityEditor;
using System.Collections;
using Core.Global;

namespace Core.Editor
{
    [CustomEditor(typeof(GlobalEvent))]
    public class GlobalEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();


            base.OnInspectorGUI();
        }
    }
}

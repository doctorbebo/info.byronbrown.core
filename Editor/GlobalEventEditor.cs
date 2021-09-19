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

            GlobalEvent globalEvent = (GlobalEvent)target;
            if(GUILayout.Button("Invoke Event"))
            {
                globalEvent.InvokeGlobalEvent();
            }
        }
    }
}

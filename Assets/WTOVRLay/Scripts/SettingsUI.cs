using UnityEngine;
using UnityEditor;

public class EditorPrefsBoolExample : EditorWindow
{
    
    [MenuItem("WT Settings/Debugging")]
    static void Init()
    {
        EditorPrefsBoolExample window = (EditorPrefsBoolExample)EditorWindow.GetWindow(typeof(EditorPrefsBoolExample), true, "Debugging");
        window.Show();
    }

    void OnGUI()
    {
        Settings.Unity.PrintEvents = EditorGUILayout.BeginToggleGroup("Print Events", Settings.Unity.PrintEvents);
        EditorGUILayout.EndToggleGroup();
        Settings.Unity.PrintInfo = EditorGUILayout.BeginToggleGroup("Print Info", Settings.Unity.PrintInfo);
        EditorGUILayout.EndToggleGroup();

    }
}
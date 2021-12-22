using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{
    [MenuItem("Window/AAA")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<MyWindow>().Show();
    }
}

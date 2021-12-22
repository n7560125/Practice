using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerScript))]
public class PlayerScriptEditor : Editor
{
    private SerializedProperty m_ItemListProp;
    private SerializedProperty m_DataProp;
    public void DrawUILine(Color color, int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
       // r.height = thickness;
        int iHalfPad = padding/2;
        r.y += iHalfPad;
        //r.x -= 2;
       // r.width += 6;
        EditorGUI.DrawRect(r, color);
    }

    void OnEnable()
    {
        m_ItemListProp = serializedObject.FindProperty("m_Items");
        m_DataProp = serializedObject.FindProperty("m_Data");
    }

    void DoListProperty(SerializedProperty prop, string sName)
    {
        if(EditorGUILayout.PropertyField(m_ItemListProp, new GUIContent(sName)))
        {
            m_ItemListProp.arraySize = EditorGUILayout.IntField("Size", m_ItemListProp.arraySize);
            for (int i = 0; i < m_ItemListProp.arraySize; i++)
            {
              //  EditorGUILayout.LabelField("ddd " + i.ToString());
                m_ItemListProp.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField("Item" + i.ToString(), m_ItemListProp.GetArrayElementAtIndex(i).stringValue);
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        //return;
       // EditorGUI.BeginChangeCheck();
        PlayerScript myTarget = (PlayerScript)target;
        EditorGUILayout.LabelField("Play Name", myTarget.m_sName);
        
        DrawUILine(Color.green);

        DoListProperty(m_ItemListProp, "Items-------");

        DrawUILine(Color.green);

        Color cOri = GUI.backgroundColor;
        GUI.backgroundColor = Color.green;
       if ( GUILayout.Button("Do Something"))
        {
            Debug.Log("Do Something");
        }
        GUI.backgroundColor = cOri;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Do Something1"))
        {
            Debug.Log("Do Something");
        }
        if (GUILayout.Button("Do Something2"))
        {
            Debug.Log("Do Something");
        }

        GUILayout.EndHorizontal();

        myTarget.m_bShowData = EditorGUILayout.Toggle("Show Data", myTarget.m_bShowData);
        if(myTarget.m_bShowData)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.FloatField("你", 1.0f);
           // if (EditorGUILayout.PropertyField(m_DataProp, new GUIContent("Data")))
            {
                SerializedProperty prop = m_DataProp.FindPropertyRelative("m_fHp");
                prop.floatValue = EditorGUILayout.FloatField("血量", prop.floatValue);
                prop = m_DataProp.FindPropertyRelative("m_fMp");
                prop.floatValue = EditorGUILayout.FloatField("Mp", prop.floatValue);
                prop = m_DataProp.FindPropertyRelative("m_fAttackPower");
                prop.floatValue = EditorGUILayout.FloatField("AttackPower", prop.floatValue);
            }
            EditorGUI.indentLevel--;
        }

       // serializedObject.ApplyModifiedProperties();
    }
}

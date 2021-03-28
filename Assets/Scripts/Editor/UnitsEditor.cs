/*using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Unit))]
[CanEditMultipleObjects]

public class UnitsEditor : Editor
{
    Unit subject;
    SerializedProperty unitType;
    SerializedProperty unitParam;

    void OnEnable()
    {
        subject = target as Unit;

        unitType = serializedObject.FindProperty("Type");
        unitParam = serializedObject.FindProperty("Parametrs");


    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(unitType);

        if (subject.Type == Unit.UnitType.Messenger)
        {
            EditorGUILayout.PropertyField(unitParam);
            EditorGUILayout.PropertyField(unitParam.FindPropertyRelative("Name"));
        }
    }

}*/

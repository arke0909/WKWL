using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using System.Reflection.Emit;
using UnityEngine.UIElements;

[CustomEditor(typeof(TextEffectSO))]
public class CustomTextEffectSO : Editor
{
    private SerializedProperty _contentsText;
    private SerializedProperty _textSize;
    private SerializedProperty _textColor;
    private SerializedProperty _isShake;
    private SerializedProperty _shakeType;
    private SerializedProperty _shakePower;

    private void OnEnable()
    {
        _contentsText = serializedObject.FindProperty("_contentsText");
        _textSize = serializedObject.FindProperty("_textSize");
        _textColor = serializedObject.FindProperty("_textColor");
        _isShake = serializedObject.FindProperty("_isShake");
        _shakeType = serializedObject.FindProperty("_shakeType");
        _shakePower = serializedObject.FindProperty("_shakePower");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_contentsText);
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField(_textSize.displayName,GUILayout.Width(Width(_textSize.displayName)));
            EditorGUILayout.PropertyField(_textSize, GUIContent.none,GUILayout.Width(50));
            EditorGUILayout.LabelField(_textColor.displayName, GUILayout.Width(Width(_textColor.displayName)));
            EditorGUILayout.PropertyField(_textColor, GUIContent.none, GUILayout.Width(70));
        }
        EditorGUILayout.EndHorizontal();

        //EditorGUILayout.LabelField(_isShake.displayName, GUILayout.Width(Width(_isShake.displayName)));
        EditorGUILayout.PropertyField(_isShake);

        if(_isShake.boolValue == true)
        {
            EditorGUILayout.PropertyField(_shakeType);
            EditorGUILayout.PropertyField(_shakePower);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private float Width(string str)
    {
        return str.Length * 7;
    }
}

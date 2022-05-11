using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(CustomSlider))]
public class CustomSliderEditor : SliderEditor
{
    private SerializedProperty m_InteractableProperty;

    protected override void OnEnable()
    {
        m_InteractableProperty = serializedObject.FindProperty("m_Interactable");

    }

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        var changeSliderType = new
        PropertyField(serializedObject.FindProperty(CustomSlider.ChangeSliderType));
        var curveEase = new
        PropertyField(serializedObject.FindProperty(CustomSlider.CurveEase));
        var duration = new PropertyField(serializedObject.FindProperty(CustomSlider.Duration));
        var streight = new PropertyField(serializedObject.FindProperty(CustomSlider.Streight));
        var tweenLabel = new Label("Settings Tween");
        var intractableLabel = new Label("Intractable");

        root.Add(tweenLabel);
        root.Add(changeSliderType);
        root.Add(curveEase);
        root.Add(duration);
        root.Add(streight);
        root.Add(intractableLabel);
        root.Add(new IMGUIContainer(OnInspectorGUI));
        root.Add(new Label("Play Animation"));

        return root;
    }

    public override void OnInspectorGUI()
    {
        CustomSlider myScript = (CustomSlider)target;
        if (GUI.Button(new Rect(250, 10, 200, 25), "Play Animation"))
        {
            myScript.StartAnimation();
        }

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_InteractableProperty);
        EditorGUI.BeginChangeCheck();
        serializedObject.ApplyModifiedProperties();
    }
}

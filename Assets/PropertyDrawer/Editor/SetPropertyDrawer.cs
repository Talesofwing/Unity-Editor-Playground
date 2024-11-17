using System;
using System.Reflection;

using UnityEngine;
using UnityEditor;

namespace zer0.Editor {

    [CustomPropertyDrawer(typeof(SetPropertyAttribute))]
    public class SetPropertyDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);

            SetPropertyAttribute setProperty = attribute as SetPropertyAttribute;
            if (EditorGUI.EndChangeCheck()) {
                setProperty.IsDirty = true;
            } else if (setProperty.IsDirty) {
                object parent = property.serializedObject.targetObject;
                Type type = parent.GetType();

                PropertyInfo pi = type.GetProperty(setProperty.Name);
                if (pi == null) {
                    Debug.LogError("Invalied property name: " + setProperty.Name);
                } else {
                    pi.SetValue(parent, fieldInfo.GetValue(parent), null);
                }

                setProperty.IsDirty = false;
            }
        }
    }
}

using SilentWolfHelper.CustomInspector.Attributes;
using UnityEditor;
using UnityEngine;

namespace Combat.CustomInspector.Editor
{
    [CustomPropertyDrawer(typeof(LeftToggleAttribute))]
    public class LeftToggleDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.height = 16;
            if (property.propertyType == SerializedPropertyType.Boolean)
            {
                if (attribute is LeftToggleAttribute leftToggle) property.boolValue = leftToggle.labelOverride == string.Empty ? EditorGUI.ToggleLeft(position, label, property.boolValue) : EditorGUI.ToggleLeft(position, leftToggle.labelOverride, property.boolValue);
            }
            else EditorGUI.LabelField(position, label.text, "Use LeftToggle with bool");
        }
    }
}
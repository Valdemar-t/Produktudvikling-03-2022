using CustomInspector.Attributes;
using UnityEditor;
using UnityEngine;

namespace Combat.CustomInspector.Editor
{
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);
 
            bool wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (!condHAtt.HideInInspector || enabled)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
 
            GUI.enabled = wasEnabled;
        }
 
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);

            return !condHAtt.HideInInspector || enabled ? EditorGUI.GetPropertyHeight(property, label) : -EditorGUIUtility.standardVerticalSpacing;
        }
 
        private static bool GetConditionalHideAttributeResult(ConditionalHideAttribute condHAtt, SerializedProperty property)
        {
            bool enabled = true;
            string propertyPath = property.propertyPath;
            string conditionPath = propertyPath.Replace(property.name, condHAtt.ConditionalSourceField);
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);
 
            if (sourcePropertyValue != null) enabled = sourcePropertyValue.boolValue;
            else Debug.LogWarning($"Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: {condHAtt.ConditionalSourceField}");

            return enabled;
        }
    }
}
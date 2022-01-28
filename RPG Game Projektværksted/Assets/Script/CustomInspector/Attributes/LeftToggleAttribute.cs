using UnityEngine;

namespace CustomInspector.Attributes
{
    public class LeftToggleAttribute : PropertyAttribute
    {
        public readonly string labelOverride = string.Empty;

        public LeftToggleAttribute() {}

        public LeftToggleAttribute(string labelOverride) => this.labelOverride = labelOverride;
    }
}
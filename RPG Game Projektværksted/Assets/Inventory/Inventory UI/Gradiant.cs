using TMPro;
using UnityEngine;

public class TextGradient : MonoBehaviour {

    private void Start () => ApplyGradient ();

    private void ApplyGradient () 
    {
        TMP_Text textComponent = GetComponent<TMP_Text>();
        textComponent.ForceMeshUpdate();
        TMP_TextInfo textInfo = textComponent.textInfo;
        int count = textInfo.characterCount, i, index = 0;
        Color[] steps = GetGradients (textComponent.colorGradient.topLeft, textComponent.colorGradient.topRight, count + 1);
        VertexGradient[] gradients = new VertexGradient[steps.Length];
        for (i = 0; i < steps.Length - 1; i++) gradients[i] = new VertexGradient(steps[i], steps[i + 1], steps[i], steps[i + 1]);
        
        while (index < count) 
        {
            int materialIndex = textInfo.characterInfo[index].materialReferenceIndex, vertexIndex = textInfo.characterInfo[index].vertexIndex;
            Color32[] colors = textInfo.meshInfo[materialIndex].colors32;
            if (textInfo.characterInfo[index].isVisible) 
            {
                colors[vertexIndex + 0] = gradients[index].bottomLeft;
                colors[vertexIndex + 1] = gradients[index].topLeft;
                colors[vertexIndex + 2] = gradients[index].bottomRight;
                colors[vertexIndex + 3] = gradients[index].topRight;
                textComponent.UpdateVertexData (TMP_VertexDataUpdateFlags.Colors32);
            }
            index++;
        }
    }

    private static Color[] GetGradients (Color start, Color end, int steps) 
    {
        Color[] result = new Color[steps];
        float r = (end.r - start.r) / (steps - 1);
        float g = (end.g - start.g) / (steps - 1);
        float b = (end.b - start.b) / (steps - 1);
        float a = (end.a - start.a) / (steps - 1);
        for (int i = 0; i < steps; i++) result[i] = new Color(start.r + r * i, start.g + g * i, start.b + b * i, start.a + a * i);
        return result;
    }
}
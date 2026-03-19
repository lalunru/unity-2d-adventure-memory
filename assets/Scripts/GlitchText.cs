using TMPro;
using UnityEngine;

public class GlitchText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float glitchDuration = 0.05f;
    public float glitchInterval = 0.2f;
    private string originalText;

    void Start()
    {
        originalText = textMesh.text;
        InvokeRepeating(nameof(Glitch), glitchInterval, glitchInterval);
    }

    void Glitch()
    {
        textMesh.text = GetGlitchedText(originalText);
        Invoke(nameof(ResetText), glitchDuration);
    }

    void ResetText()
    {
        textMesh.text = originalText;
    }

    string GetGlitchedText(string text)
    {
        string[] glitchChars = new string[] { "¢Ì", "¢Ê", "¡Ø", "#", "@", "%", "¢Æ" };
        int index = Random.Range(0, text.Length);
        char[] chars = text.ToCharArray();
        chars[index] = glitchChars[Random.Range(0, glitchChars.Length)][0];
        return new string(chars);
    }
}

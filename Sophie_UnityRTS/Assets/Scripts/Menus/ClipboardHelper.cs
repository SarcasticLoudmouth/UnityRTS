using UnityEngine;



public class ClipboardHelper : MonoBehaviour
{
    // Public method to copy text to clipboard
    public void CopyTextToClipboard(string text)
    {
        GUIUtility.systemCopyBuffer = text;
        Debug.Log("Copied to clipboard: " + text);
    }
}

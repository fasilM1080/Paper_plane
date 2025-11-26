using UnityEngine;

public class FileManager : MonoBehaviour
{
    [Header("Assign JSON File Here")]
    public TextAsset jsonData;
    public string GetJsonLevelData()
    {
        if (jsonData != null)
        {
            Debug.Log("JSON file loaded successfully : "+jsonData.text);
            return jsonData.text;
        }

        Debug.LogError("JSON file not assigned!");
        return null;
    }
}

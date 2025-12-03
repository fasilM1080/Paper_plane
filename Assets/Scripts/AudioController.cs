using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    None,
    UiBg,
    GameBg,
    ButtonClick,
    Winnig
}

[System.Serializable]
public class AudioData
{
    public AudioType type = AudioType.None;
    public AudioClip clip = null;
}

public class AudioController : MonoBehaviour
{
    [Header("Audio List")]
    public List<AudioData> audioList = new List<AudioData>();

    private Dictionary<AudioType, AudioClip> ClipCollection = new Dictionary<AudioType, AudioClip>();

    private void Awake()
    {
        InitializeMap();
    }

    private void InitializeMap()
    {
        foreach (var data in audioList)
        {
            if (data.clip != null)
            {
                if (!ClipCollection.ContainsKey(data.type))
                {
                    ClipCollection.Add(data.type, data.clip);
                }
            }
        }
    }

    public AudioClip GetAudio(AudioType type)
    {
        ClipCollection.TryGetValue(type, out AudioClip clip);
        return clip;
    }
}

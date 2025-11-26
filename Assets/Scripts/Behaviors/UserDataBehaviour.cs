using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UserDataBehaviour : MonoBehaviour
{
    public static UserDataBehaviour Instance;
    [SerializeField] private FileManager fileManager;
    private LevelRoot levelRoot;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // ---Initialzing---

        InitLevelData();
    }

    private void InitLevelData()
    {
        if (fileManager != null)
        {
            string jsonString = fileManager.GetJsonLevelData();
            levelRoot = JsonUtility.FromJson<LevelRoot>(jsonString);
        }
    }

    public LevelData GetLevelData(int levelID)
    {
        return levelRoot.levels[levelID];
    }
}

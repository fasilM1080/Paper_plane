using UnityEngine;

public class UserDataBehaviour : MonoBehaviour
{
    public static UserDataBehaviour Instance;
    [SerializeField] private FileManager fileManager;
    private LevelRoot levelRoot;
    void Awake()
    {
        Instance = this;
        // ---Initialzing---

        InitLevelData();
    }
    void Start()
    {
        SaveLevel(1);
        foreach (var level in levelRoot.levels)
        {
            var value = PlayerPrefs.GetInt(level.level_id.ToString(), 0);
            level.isLevelUnlocked = value == 1 ? true : false;
        }
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
        var leveldata = levelRoot.levels[levelID-1];
        return leveldata;
    }
    public bool IsFirstUser()
    {
    if (!PlayerPrefs.HasKey("first"))
    {
        PlayerPrefs.SetInt("first", 1);
        PlayerPrefs.Save();
        return true;
    }

    return false;
    }
    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt(levelRoot.levels[level-1].level_id.ToString(),1);
    }

}

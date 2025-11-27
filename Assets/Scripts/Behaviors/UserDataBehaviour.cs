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
        var leveldata = levelRoot.levels[levelID-1];
        Debug.Log("Level Data of Level : " + leveldata.level_id);
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

}

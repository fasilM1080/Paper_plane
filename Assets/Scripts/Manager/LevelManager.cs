
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Level Control")]
    [SerializeField] private Transform CheckpointParent;


    private LevelData currentLevelData;
    private CheckPoint_Controller checkPointController;


    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        checkPointController = FindAnyObjectByType<CheckPoint_Controller>();
    }

    public void SetCurrentLevelData(int level)
    {
        currentLevelData = UserDataBehaviour.Instance.GetLevelData(level);
    }

    public LevelData GetCurrentLevelData()
    {
        return currentLevelData;
    }

    public bool GetLevelLock(int level)
    {
        return UserDataBehaviour.Instance.GetLevelData(level).isLevelUnlocked;
    }

    public int GetCurrentLevelNumber()
    {
        return currentLevelData.level_id;
    }

    public void UnlockLevel(int level)
    {
        var lvl = UserDataBehaviour.Instance.GetLevelData(level);
        lvl.isLevelUnlocked = true;
    }

    // public void SaveLevel(int level)
    // {
    //     UserDataBehaviour.Instance.SaveLevel(level);
    // }
    public void LoadLevelData(int levelID)
    {
        var levelData = UserDataBehaviour.Instance.GetLevelData(levelID);
        int i = 0;
        foreach (Transform checkpoint in CheckpointParent)
        {
            Vector3 pos = new Vector3(
                levelData.checkpoints[i].position.x,
                levelData.checkpoints[i].position.y,
                levelData.checkpoints[i].position.z
            );
            checkpoint.position = pos;
            checkpoint.gameObject.SetActive(levelData.checkpoints[i].enabled);
            i++;
        }
        checkPointController.InitCheckpoint();
    }
}


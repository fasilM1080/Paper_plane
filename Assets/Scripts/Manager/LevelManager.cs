
using UnityEngine;
using UnityEngine.Playables;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Level Control")]
    [SerializeField] private Transform CheckpointParent;
    [SerializeField] private Transform Player;    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private Timmer timmer;


    private LevelData currentLevelData;
    private CheckPoint_Controller checkPointController;


    private void Awake()
    {
       Instance = this;
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
       UserDataBehaviour.Instance.SaveLevel(level);
    }
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
        Vector3 playerpos = new Vector3(
            levelData.SpawnPosition.x,
            levelData.SpawnPosition.y,
            levelData.SpawnPosition.z
            );
        Player.position = playerpos;
        timeline.Play();
        checkPointController.InitCheckpoint();
        timmer.StartTimmer(levelData.min_completion_time);
    }
}


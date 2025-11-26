using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform CheckpointParent;
    public int currentLevelID = 0;
    void Start()
    {
        LoadLevelData(currentLevelID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevelData(int levelID)
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
    }
}

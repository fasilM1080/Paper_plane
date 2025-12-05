using System;
using System.Collections.Generic;

[Serializable]
public class Position
{
    public float x;
    public float y;
    public float z;
}

[Serializable]
public class Checkpoint
{
    public int id;
    public Position position;
    public bool enabled;
}

[Serializable]
public class LevelData
{
    public Position SpawnPosition;
    public int level_id;

    public float min_completion_time;
    
    public List<Checkpoint> checkpoints;

    public bool isLevelUnlocked;
}

[Serializable]
public class LevelRoot
{
    public List<LevelData> levels;
}
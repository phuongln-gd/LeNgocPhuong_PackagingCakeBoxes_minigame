using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Level[] mapPrefabs; // 0: 3x3, 1: 4x4
    public FillCell[] fillCellPrefabs; // 0: 3x3, 1: 4x4
    public Level currentLevel;
    public int levelIndex;

    //public GamePlayController gamePlayController;

    public void LoadLevel(int level)
    {
        if(currentLevel != null)
        {
            currentLevel.DespawnLevel();
        }
        levelIndex = level;
        int typeMap = GameManager.Instance.mapData.getMapByID(level).typeMap;
        currentLevel = Instantiate(mapPrefabs[typeMap], UIManager.Instance.GetUI<GamePlayUi>().gamePanel.transform);
        currentLevel.SpawnLevel(level);
    }

    public void ResetLevel()
    {
        LoadLevel(levelIndex);
    }

    public void NextLevel()
    {
        levelIndex += 1;
        if(levelIndex > GameManager.Instance.mapData.mapAmount)
        {
            levelIndex = 1;
        }
        LoadLevel(levelIndex);
    }
}

using UnityEngine;

public enum GameState
{
    MainMenu,
    Win,
    Lose,
    GamePlay,
    Guide,
    SelectLevel
}

public class GameManager : Singleton<GameManager>
{
    public MapData mapData;
    public UserData userData;
    private static GameState gameState;
    private void Awake()
    {
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void Start()
    {
        UIManager.Instance.OpenUI<MainMenuUI>();
    }
    public static void ChangeState(GameState state)
    {
        gameState = state;
    }

    public static bool IsState(GameState state)
    {
        return gameState == state;
    }

}

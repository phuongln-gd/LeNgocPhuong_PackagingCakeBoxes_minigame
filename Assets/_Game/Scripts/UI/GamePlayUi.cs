using UnityEngine;

public class GamePlayUi : UICanvas
{
    public GameObject gamePanel;
    [SerializeField] Clock countdownTime;
    public void HomeButton()
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            UIManager.Instance.OpenUI<MainMenuUI>();
            Close();
        }
    }

    public void RetryButton()
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            LevelManager.Instance.ResetLevel();
            ResetTime();
        }
    }
    public override void Open()
    {
        base.Open();
        GameManager.ChangeState(GameState.GamePlay);
        ResetTime();
    }
    public override void Close()
    {
        base.Close();
        countdownTime.StopTime();
    }
    public void ResetTime()
    {
        countdownTime.ResetCountdown();
    }

}

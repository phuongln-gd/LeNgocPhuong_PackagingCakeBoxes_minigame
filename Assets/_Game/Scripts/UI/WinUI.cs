using UnityEngine;

public class WinUI : UICanvas
{
    public void HomeButton()
    {
        UIManager.Instance.OpenUI<MainMenuUI>();
        UIManager.Instance.CloseUI<GamePlayUi>();
        Close();
    }

    public void RetryButton()
    {
        GameManager.ChangeState(GameState.GamePlay);
        LevelManager.Instance.ResetLevel();
        UIManager.Instance.GetUI<GamePlayUi>().ResetTime();
        Close();
    }

    public void NextButton()
    {
        GameManager.ChangeState(GameState.GamePlay);
        LevelManager.Instance.NextLevel();
        UIManager.Instance.GetUI<GamePlayUi>().ResetTime();
        Close();
    }

    public override void Open()
    {
        base.Open();
        GameManager.ChangeState(GameState.Win);
    }
}

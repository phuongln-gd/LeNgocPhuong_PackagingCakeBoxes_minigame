using UnityEngine;

public class LoseUI : UICanvas
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

    public override void Open()
    {
        base.Open();
        GameManager.ChangeState(GameState.Lose);
    }
}

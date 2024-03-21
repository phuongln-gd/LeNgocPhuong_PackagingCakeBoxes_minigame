using UnityEngine;

public class MainMenuUI : UICanvas
{
    public void PlayButton()
    {
        UIManager.Instance.OpenUI<SelectLevelUI>();
        Close();
    }

    public void GuildButton()
    {
        UIManager.Instance.OpenUI<GuildeUI>();
        Close();
    }

    public override void Open()
    {
        base.Open();
        GameManager.ChangeState(GameState.MainMenu);
    }
}

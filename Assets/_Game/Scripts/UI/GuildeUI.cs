using UnityEngine;

public class GuildeUI : UICanvas
{
    public void CloseButton()
    {
        UIManager.Instance.OpenUI<MainMenuUI>();
        Close();
    }

    public override void Open()
    {
        base.Open();
        GameManager.ChangeState(GameState.Guide);
    }
}

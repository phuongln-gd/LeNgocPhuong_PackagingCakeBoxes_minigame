using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelUI : UICanvas
{
    [SerializeField] List<ButtonLevel> buttons;
    
    public void BackButton()
    {
        UIManager.Instance.OpenUI<MainMenuUI>();
        Close();
    }

    public override void Open()
    {
        base.Open();
        GameManager.ChangeState(GameState.SelectLevel);   
        ShowLevelData();
    }

    public void ShowLevelData()
    {
        int currentLevel = GameManager.Instance.userData.PlayingLevel;
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < currentLevel)
            {
                buttons[i].UnlockLevel(i + 1);
            }
            else
            {
                buttons[i].LockLevel();
            }
        }
    }

    public void OpenLevel(int level)
    {
        // GameManager.Instance.mapData.mapAmount la` so map nguoi` choi da unlock
        if (level <= GameManager.Instance.mapData.mapAmount && buttons[level - 1].isUnlock)
        {
            UIManager.Instance.OpenUI<GamePlayUi>();
            LevelManager.Instance.LoadLevel(level);
            Close();
        }
    }
}

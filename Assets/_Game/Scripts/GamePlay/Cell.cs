using UnityEngine;
using System.Collections.Generic;
public class Cell : MonoBehaviour
{
    public Cell right;
    public Cell left;
    public Cell up;
    public Cell down;

    public Type type; // box: 2, cake: 3

    protected FillCell fillCell;

    private void OnEnable()
    {
        GamePlayController.slide += OnSlide;
    }

    private void OnDisable()
    {
        GamePlayController.slide -= OnSlide;
    }
    private void OnSlide(string whatWasSent)
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            if (whatWasSent == "up")
            {
                Cell currentCell = this;
                SlideUp(currentCell);
            }
            if (whatWasSent == "right")
            {
                Cell currentCell = this;
                SlideRight(currentCell);
            }
            if (whatWasSent == "down")
            {
                Cell currentCell = this;
                SlideDown(currentCell);
            }
            if (whatWasSent == "left")
            {
                Cell currentCell = this;
                SlideLeft(currentCell);
            }
        }
    }

    private void SlideLeft(Cell currentCell)
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            if (currentCell.type == Type.BOX || currentCell.type == Type.CAKE)
            {
                Cell nextCell = currentCell.left;
                if (nextCell == null || nextCell.type == Type.OBSTACLE)
                {
                    return;
                }
                if (nextCell.type != Type.NONE)
                {
                    SlideLeft(nextCell);
                }
                if (nextCell.type == Type.NONE)
                {
                    while (nextCell.left != null)
                    {
                        if (nextCell.left.type == Type.NONE)
                            nextCell = nextCell.left;
                        else
                        {
                            SlideLeft(nextCell);
                            break;
                        }
                    }
                    currentCell.fillCell.transform.SetParent(nextCell.transform);
                    nextCell.SetFillCell(currentCell.fillCell);
                    currentCell.SetFillCell(null);
                    nextCell.type = currentCell.type;
                    currentCell.type = Type.NONE;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    private void SlideDown(Cell currentCell)
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            if (currentCell.type == Type.BOX || currentCell.type == Type.CAKE)
            {
                Cell nextCell = currentCell.down;
                if (currentCell.down == null || nextCell.type == Type.OBSTACLE)
                {
                    return;
                }
                if (nextCell.type != Type.NONE)
                {
                    if (currentCell.type == Type.CAKE)
                    {
                        Debug.Log("win 1");
                        OnWin();
                    }
                    else
                    {
                        SlideDown(nextCell);
                    }
                }
                if (nextCell.type == Type.NONE)
                {
                    while (nextCell.down != null)
                    {
                        if(nextCell.down.type == Type.NONE)
                        {
                            nextCell = nextCell.down;
                        }
                        else
                        {
                            if(currentCell.type == Type.CAKE && nextCell.down.type == Type.BOX)
                            {
                                OnWin();
                                Debug.Log("win 2");
                                break;
                            }
                            else
                            {
                                SlideDown(nextCell);
                                break;
                            }
                        }
                    }
                    currentCell.fillCell.transform.SetParent(nextCell.transform);
                    nextCell.SetFillCell(currentCell.fillCell);
                    currentCell.SetFillCell(null);
                    nextCell.type = currentCell.type;
                    currentCell.type = Type.NONE;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    public void OnWin()
    {
        UIManager.Instance.OpenUI<WinUI>();
        if(LevelManager.Instance.levelIndex == GameManager.Instance.userData.PlayingLevel)
        {
            if(GameManager.Instance.userData.PlayingLevel < GameManager.Instance.mapData.mapAmount)
                GameManager.Instance.userData.SetIntData(UserData.Key_PlayingLevel, ref GameManager.Instance.userData.PlayingLevel, GameManager.Instance.userData.PlayingLevel + 1);
        }
    }

    private void SlideRight(Cell currentCell)
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            if (currentCell.type == Type.BOX || currentCell.type == Type.CAKE)
            {
                Cell nextCell = currentCell.right;
                if (nextCell == null || nextCell.type == Type.OBSTACLE)
                {
                    return;
                }
                if (nextCell.type != Type.NONE)
                {
                    SlideRight(nextCell);
                }
                if (nextCell.type == Type.NONE)
                {
                    while (nextCell.right != null)
                    {
                        if (nextCell.right.type == Type.NONE)
                            nextCell = nextCell.right;
                        else
                        {
                            SlideRight(nextCell);
                            break;
                        }
                    }
                    currentCell.fillCell.transform.SetParent(nextCell.transform);
                    nextCell.SetFillCell(currentCell.fillCell);
                    currentCell.SetFillCell(null);
                    nextCell.type = currentCell.type;
                    currentCell.type = Type.NONE;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    void SlideUp(Cell currentCell)
    {
        if (GameManager.IsState(GameState.GamePlay))
        {
            if (currentCell.type == Type.BOX || currentCell.type == Type.CAKE)
            {
                Cell nextCell = currentCell.up;
                if (nextCell == null || nextCell.type == Type.OBSTACLE)
                {
                    return;
                }
                if(nextCell.type != Type.NONE)
                {
                    SlideUp(nextCell);
                }
                if (nextCell.type == Type.NONE)
                {
                    while (nextCell.up != null )
                    {
                        if(nextCell.up.type == Type.NONE)
                            nextCell = nextCell.up;
                        else
                        {
                            SlideUp(nextCell);
                            break;
                        }
                    }
                    currentCell.fillCell.transform.SetParent(nextCell.transform);
                    nextCell.SetFillCell(currentCell.fillCell);
                    currentCell.SetFillCell(null);
                    nextCell.type = currentCell.type;
                    currentCell.type = Type.NONE;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    public void SetFillCell(FillCell fillCell)
    {
        this.fillCell = fillCell;
    }

    public FillCell GetFillCell()
    {
        return fillCell;
    }
}

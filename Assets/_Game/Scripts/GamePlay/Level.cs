using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum Type
{
    NONE,
    OBSTACLE,
    BOX,
    CAKE
}

public class Level : MonoBehaviour
{
    [SerializeField] int typeMap; // 0: 3x3, 1: 4x4
    public List<Cell> cells;
    [SerializeField] private List<Sprite> sprites; // 0: cake, 1: obstacle, 2: box
    
    public void SpawnLevel(int level)
    {
        Map map = GameManager.Instance.mapData.getMapByID(level);
        int typeMap = map.typeMap;
        for (int i = 0; i < cells.Count; i++)
        {
            if (i == map.cakePos - 1)
            {
                cells[i].type = Type.CAKE;
                FillCell fillCell = Instantiate(LevelManager.Instance.fillCellPrefabs[typeMap], cells[i].transform); 
                fillCell.GetComponent<Image>().sprite = sprites[0];
                fillCell.OnInit();
                cells[i].SetFillCell(fillCell);
            }
            else if (i == map.boxPos - 1)
            {
                cells[i].type = Type.BOX;
                FillCell fillCell = Instantiate(LevelManager.Instance.fillCellPrefabs[typeMap], cells[i].transform);
                fillCell.GetComponent<Image>().sprite = sprites[2];
                fillCell.OnInit();
                cells[i].SetFillCell(fillCell);
            }
            else
            {
                bool isObs = false;
                for (int j = 0; j < map.obstaclePos.Length; j++)
                {
                    if (i == map.obstaclePos[j] - 1)
                    {
                        cells[i].type = Type.OBSTACLE;
                        FillCell fillCell = Instantiate(LevelManager.Instance.fillCellPrefabs[typeMap], cells[i].transform);
                        fillCell.GetComponent<Image>().sprite = sprites[1];
                        fillCell.OnInit();
                        cells[i].SetFillCell(fillCell);
                        isObs = true;
                        break;
                    }
                }
                if (!isObs)
                {
                    cells[i].type = Type.NONE;
                    cells[i].SetFillCell(null);
                }
            }
        }
    }

    public void DespawnLevel()
    {
        Destroy(gameObject);
    }

}

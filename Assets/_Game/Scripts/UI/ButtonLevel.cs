using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonLevel : MonoBehaviour
{
    [SerializeField] private List<Sprite> starSprites; // 0: lock, 1: unlock
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] List<GameObject> stars;
    [SerializeField] private Image lock_up;
    public bool isUnlock = false;
    public void LockLevel()
    {
        for(int i = 0; i< stars.Count; i++)
        {
            stars[i].GetComponent<Image>().sprite = starSprites[0];
        }
        lock_up.gameObject.SetActive(true);
        textLevel.text = "";
        isUnlock = false;
    }

    public void UnlockLevel(int level)
    {
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].GetComponent<Image>().sprite = starSprites[1];
        }
        lock_up.gameObject.SetActive(false);
        SetTextLevel(level);
        isUnlock = true;
    }

    public void SetTextLevel(int level)
    {
        textLevel.text = level.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private int minutes = 0;
    [SerializeField] private int seconds = 15;
    [SerializeField] TextMeshProUGUI countdownText;
    private bool isCounting = false;

    public void ResetCountdown()
    {
        minutes = 0;
        seconds = 45;
        UpdateCountdownText();
        if (!isCounting)
        {
            StartCoroutine(StartCountdown());
        }
    }

    IEnumerator StartCountdown()
    {
        isCounting = true;
        while (seconds > 0 && GameManager.IsState(GameState.GamePlay))
        {
            yield return new WaitForSeconds(1);
            seconds--;
            UpdateCountdownText();
            if(seconds == 0)
            {
                UIManager.Instance.OpenUI<LoseUI>();
            }
        }
        isCounting = false;
    }
    
    void UpdateCountdownText()
    {
        countdownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StopTime()
    {
        isCounting = false;
        StopAllCoroutines();
    }
}

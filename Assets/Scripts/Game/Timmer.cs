
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timmer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerTxt;
    private float maxTime;
    public void StartTimmer(float time)
    {
        maxTime = time;
        TimerTxt.text = maxTime.ToString();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        float timeLeft = maxTime;

    while (timeLeft > 0)
    {
        if (!GameManager.Instance.isGameRunning)
            yield break;

        TimerTxt.text = Mathf.Ceil(timeLeft).ToString();
        yield return new WaitForSecondsRealtime(1f);
        timeLeft--;
    }

    TimerTxt.text = "0";
    UiManager.Instance.EnablePanel(PanelType.GameOverMenu);
    GameManager.Instance.isGameRunning = false;
    }
}

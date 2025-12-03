using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : UiPanel
{
   [SerializeField] private Button Restart_Btn;
    [SerializeField] private Button Home_Btn;
    void OnEnable()
    {
        Restart_Btn.onClick.AddListener(OnRestart);
        Home_Btn.onClick.AddListener(OnHome);
    }
    void OnRestart()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        GameManager.Instance.ResetGame();
        UiManager.Instance.DisablePanel(PanelType.GameOverMenu);
        GameManager.Instance.isGameRunning = true;
    }
    void OnHome()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.MainMenu);
        GameManager.Instance.ResetGame();
    }
    void OnDisable()
    {
        Restart_Btn.onClick.RemoveListener(OnRestart);
        Home_Btn.onClick.RemoveListener(OnHome);
    }
}

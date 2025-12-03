using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : UiPanel
{
   [SerializeField] private Button Resume_Btn;
   [SerializeField] private Button Restart_Btn;
    [SerializeField] private Button Home_Btn;
    void OnEnable()
    {
        Resume_Btn.onClick.AddListener(OnResume);
        Restart_Btn.onClick.AddListener(OnRestart);
        Home_Btn.onClick.AddListener(OnHome);
    }
    void OnResume()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.DisablePanel(PanelType.PauseMenu);
        GameManager.Instance.isGameRunning = true;
    }
    void OnRestart()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        GameManager.Instance.ResetGame();
        UiManager.Instance.DisablePanel(PanelType.PauseMenu);
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
        Resume_Btn.onClick.RemoveListener(OnResume);
        Restart_Btn.onClick.RemoveListener(OnRestart);
        Home_Btn.onClick.RemoveListener(OnHome);
    }
}

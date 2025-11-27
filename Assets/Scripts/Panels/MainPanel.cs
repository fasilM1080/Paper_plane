using System;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UiPanel
{
    [Header("Buttons")]
    public Button playButton;
    // public Button settingsButton;
    // public Button exitButton;


    private void OnEnable()
    {
        // if (!GameManager.Instance.isGameRestart)
        // {
        //     GameManager.Instance.isGameLevelBased = false;
        // }

        playButton.onClick.AddListener(OnPlay);
        // settingsButton.onClick.AddListener(OnSettings);
        // exitButton.onClick.AddListener(OnExit);
    }

    private void Start()
    {
        // if (GameManager.Instance.isGameRestart)
        // {
        //     AudioManager.Instance.PlaySfx(AudioType.Start);
        //     GameManager.Instance.isGameRestart = false;
        //     UiManager.Instance.EnablePanel(PanelType.Loading);
        // }

        // if (GameManager.Instance.isNextLevel)
        // {
        //     GameManager.Instance.isNextLevel = false;
        //     OnLevels();
        // }
    }

    private void OnPlay()
    {
        // AudioManager.Instance.PlaySfx(AudioType.Start);
        UiManager.Instance.EnablePanel(PanelType.LevelsMenu);
    }

    private void OnSettings()
    {
        // AudioManager.Instance.PlaySfx(AudioType.Enter);
        // UiManager.Instance.EnablePanel(PanelType.SettingsMenu);
    }

    private void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnPlay);
        // settingsButton.onClick.RemoveListener(OnSettings);
        // exitButton.onClick.RemoveListener(OnExit);
    }
}

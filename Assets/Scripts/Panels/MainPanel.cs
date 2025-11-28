using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UiPanel
{
    [Header("Buttons")]
    public Button playButton;
    public Button quitButton;
    public Button muteButton;
    

    public TextMeshProUGUI MuteTxt;


    private void OnEnable()
    {
        // if (!GameManager.Instance.isGameRestart)
        // {
        //     GameManager.Instance.isGameLevelBased = false;
        // }

        playButton.onClick.AddListener(OnPlay);
        quitButton.onClick.AddListener(OnQuit);
        muteButton.onClick.AddListener(OnMute);
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

    private void OnMute()
    {
        //audio manager mute functionality

        if (MuteTxt.text == "Mute")
        {
            MuteTxt.text = "Unmute";
        }
        else if (MuteTxt.text == "Unmute")
        {
            MuteTxt.text = "Mute";
        }
    }

    private void OnQuit()
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
        quitButton.onClick.RemoveListener(OnQuit);
        muteButton.onClick.RemoveListener(OnMute);
    }
}

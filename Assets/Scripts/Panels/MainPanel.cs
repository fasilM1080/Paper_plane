using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UiPanel
{
    [Header("Button")]
    public Button playButton;
    

    public TextMeshProUGUI MuteTxt;


    private void OnEnable()
    {
        // if (!GameManager.Instance.isGameRestart)
        // {
        //     GameManager.Instance.isGameLevelBased = false;
        // }

        playButton.onClick.AddListener(OnPlay);
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
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.LevelsMenu);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnPlay);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UiPanel
{
    [Header("Button")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button infoButton;
    


    private void OnEnable()
    {

        playButton.onClick.AddListener(OnPlay);
        infoButton.onClick.AddListener(OnInfo);
    }

    private void OnPlay()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.LevelsMenu);
    }
    private void OnInfo()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.InfoMenu);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(OnPlay);
        infoButton.onClick.RemoveListener(OnInfo);
    }
}

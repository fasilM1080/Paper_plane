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

        playButton.onClick.AddListener(OnPlay);
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

using UnityEngine;
using UnityEngine.UI;

public class HudPanel : UiPanel
{
    [SerializeField] private Button Pause_Btn;
    void OnEnable()
    {
        Pause_Btn.onClick.AddListener(OnPause);
    }

    void OnPause()
    {
        if (!GameManager.Instance.isGameRunning)return;

        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.PauseMenu);
        GameManager.Instance.isGameRunning = false;
    }

    void OnDisable()
    {
        Pause_Btn.onClick.RemoveListener(OnPause);
    }
}

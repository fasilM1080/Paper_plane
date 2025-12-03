using UnityEngine;
using UnityEngine.UI;

public class GameWonPanel : UiPanel
{
    [SerializeField] private Button NextLevel_Btn;
    [SerializeField] private Button Restart_Btn;
    [SerializeField] private Button Home_Btn;

    void OnEnable()
    {
        NextLevel_Btn.onClick.AddListener(OnNextLevel);
        Restart_Btn.onClick.AddListener(OnRestart);
        Home_Btn.onClick.AddListener(OnHome);
    }
    void OnNextLevel()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.LevelsMenu);
        GameManager.Instance.ResetGame();
    }
    void OnRestart()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        GameManager.Instance.ResetGame();
        UiManager.Instance.DisablePanel(PanelType.GameWonMenu);
        GameManager.Instance.isGameRunning = true;
    }
    void OnHome()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.MainMenu);
        GameManager.Instance.ResetGame();
    }
}

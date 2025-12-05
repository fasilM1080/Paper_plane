using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWonPanel : UiPanel
{
    [SerializeField] private Button NextLevel_Btn;
    [SerializeField] private Button Home_Btn;

    void OnEnable()
    {
        NextLevel_Btn.onClick.AddListener(OnNextLevel);
        Home_Btn.onClick.AddListener(OnHome);
    }
    void OnNextLevel()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnHome()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnDisable()
    {
        NextLevel_Btn.onClick.RemoveListener(OnNextLevel);
        Home_Btn.onClick.RemoveListener(OnHome);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Header("UI References")]
    public Button levelButton;
    public TextMeshProUGUI levelLabel;
    public GameObject lockIcon;

    private Animation lockAnim;

    [Header("Level Data")]
    public int levelNumber = 1;
    private bool isLocked = false;

    private void OnEnable()
    {
        if (levelButton != null)
            levelButton.onClick.AddListener(OnLevelClick);
    }

    private void Start()
    {
        lockAnim = GetComponent<Animation>();
    }

    private void OnLevelClick()
    {
        if (!isLocked)
        {
            // Clicked unlocked level
            // AudioManager.Instance.PlaySfx(AudioType.Start);
            // GameManager.Instance.currentSelectedLevel = levelNumber;
            // UiManager.Instance.EnablePanel(PanelType.Loading);
            LevelManager.Instance.LoadLevelData(levelNumber);
            GameManager.Instance.isGameRunning = true;
            UiManager.Instance.DisablePanel(PanelType.LevelsMenu);
            AudioManager.Instance.PlayBg(AudioType.GameBg);
            AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        }
        else
        {
            // Clicked locked level animation
            if (lockAnim != null)
                lockAnim.Play();
        }
    }

    public void OnLevelChanged(int level)
    {
        levelNumber = level;
    }

    private void OnDisable()
    {
        if (levelButton != null)
            levelButton.onClick.RemoveListener(OnLevelClick);
    }
}


using System;
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
    private bool islocked = false;

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
        if (islocked)
        {
            GameManager.Instance.currentlevel = levelNumber;
            LevelManager.Instance.LoadLevelData(levelNumber);
            GameManager.Instance.isGameRunning = true;
            UiManager.Instance.DisablePanel(PanelType.LevelsMenu);
            AudioManager.Instance.PlayBg(AudioType.GameBg);
            AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        }
    }

    public void OnLevelChanged(int level, bool islock)
    {
        levelNumber = level;
        islocked = islock;

        if(!this.islocked){
            lockIcon.active = true;
        }
        else
        {
            lockIcon.active = false;
        }
    }

    private void OnDisable()
    {
        if (levelButton != null)
            levelButton.onClick.RemoveListener(OnLevelClick);
    }
}


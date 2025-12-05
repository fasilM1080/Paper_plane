using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class LevelSelectorPanel : UiPanel
{
    [Header("UI References")]
    public Animation animationComponent;
    public Button nextButton;
    public Button prevButton;
    public Button backButton;

    [Header("Level Settings")]
    public int maxLevelInPage = 20;
    public int maxLevel = 40;
    public List<Level> levels = new List<Level>();
    private List<TextMeshProUGUI> levelsLabel = new List<TextMeshProUGUI>();


    private void OnEnable()
    {
        // GameManager.Instance.isGameLevelBased = true;

        nextButton.onClick.AddListener(OnNext);
        prevButton.onClick.AddListener(OnPrev);
        backButton.onClick.AddListener(OnBack);
        foreach (Level level in levels)
        {
            levelsLabel.Add(level.levelLabel);
        }

        for (int i = 0; i < maxLevelInPage; i++)
        {
            int levelNumber = i+1;

            levelsLabel[i].text = levelNumber.ToString();
            levels[i].OnLevelChanged(levelNumber,LevelManager.Instance.GetLevelLock(levelNumber));
        }
    }

    private void OnNext()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        if (animationComponent != null)
            animationComponent.Play();

        for (int i = 0; i < maxLevelInPage; i++)
        {
            int num = int.Parse(levelsLabel[i].text);
            num += maxLevelInPage;

            if (num > maxLevel)
                num -= maxLevel;

            levelsLabel[i].text = num.ToString();
            // levels[i].OnLevelChanged(num, LevelManager.Instance.GetLevelLock(num));
            levels[i].OnLevelChanged(num,LevelManager.Instance.GetLevelLock(num));

        }
    }

    private void OnPrev()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        if (animationComponent != null)
            animationComponent.Play();

        for (int i = 0; i < maxLevelInPage; i++)
        {
            int num = int.Parse(levelsLabel[i].text);
            num -= maxLevelInPage;

            if (num < 1)
                num += maxLevel;

            levelsLabel[i].text = num.ToString();
            // levels[i].OnLevelChanged(num, LevelManager.Instance.GetLevelLock(num));
            levels[i].OnLevelChanged(num,LevelManager.Instance.GetLevelLock(num));
        }
    }

    private void OnBack()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.MainMenu);
    }

    private void OnDisable()
    {
        nextButton.onClick.RemoveListener(OnNext);
        prevButton.onClick.RemoveListener(OnPrev);
        backButton.onClick.RemoveListener(OnBack);
    }
}

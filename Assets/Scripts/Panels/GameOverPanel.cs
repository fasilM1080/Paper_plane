using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : UiPanel
{
    [SerializeField] private Button Home_Btn;
    void OnEnable()
    {
        Home_Btn.onClick.AddListener(OnHome);
    }
    void OnHome()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnDisable()
    {
        Home_Btn.onClick.RemoveListener(OnHome);
    }
}

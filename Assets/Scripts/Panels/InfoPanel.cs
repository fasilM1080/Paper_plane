using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : UiPanel
{
    [SerializeField] private Button Next_Btn;
    [SerializeField] private Button Prev_Btn;
    [SerializeField] private Button Close_Btn;
    [SerializeField] private GameObject[] Contents;
    private int i = 0;
    void OnEnable()
    {
        Next_Btn.onClick.AddListener(OnNext);
        Prev_Btn.onClick.AddListener(OnPrev);
        Close_Btn.onClick.AddListener(OnClose);
    }
    private void OnNext()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        Contents[i].SetActive(false);
        i++;
        if (i > Contents.Length-1)
        {
            i = 0;     
        }
        Contents[i].SetActive(true);
    }
    private void OnPrev()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        Contents[i].SetActive(false);
        i--;
        if (i < 0)
        {
            i = Contents.Length-1;    
        }
        Contents[i].SetActive(true);
    }
    private void OnClose()
    {
        AudioManager.Instance.PlaySfx(AudioType.ButtonClick);
        UiManager.Instance.EnablePanel(PanelType.MainMenu);
    }

    void OnDisable()
    {
        Next_Btn.onClick.RemoveListener(OnNext);
        Prev_Btn.onClick.RemoveListener(OnPrev);
        Close_Btn.onClick.RemoveListener(OnClose);
    }
}

using UnityEngine;

public enum PanelType
{
    MainMenu = 0,
    LevelsMenu = 1,
    Hud = 2,
    PauseMenu = 3,
    GameOverMenu = 4,
    GameWonMenu = 5,
}

public class UiPanel : MonoBehaviour
{
    [Header("Panel Type")]
    public PanelType panelType = PanelType.MainMenu;

    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);

        if (anim != null)
        {
            anim.Play();
        }
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public PanelType GetPanelType()
    {
        return panelType;
    }
}

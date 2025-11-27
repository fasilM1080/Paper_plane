using UnityEngine;

public enum AudioType
{
    MainMenu,
}

public class UiManager : MonoBehaviour
{
    private static UiManager m_Instance;
    public static UiManager Instance => m_Instance;

    [Header("Canvas")]
    public GameObject Game_Canvas;
    public GameObject Ui_Canvas;

    [Header("Popup Manager")]
    public PopupManager popupManager;

    private void Awake()
    {
        m_Instance = this;
    }

    public void EnablePanel(PanelType type)
    {
        popupManager?.ActivatePanel(type);
    }

    public void DisablePanel(PanelType type)
    {
        popupManager?.DeactivatePanel(type);
    }

    public T GetCustomPanel<T>(PanelType type) where T : Component
    {
        var panel = popupManager?.GetPanel(type);

        if (panel != null)
            return panel.GetComponent<T>();

        return null;
    }

    public void EnableGame()
    {
        if (Game_Canvas != null)
            Game_Canvas.SetActive(true);

        if (Ui_Canvas != null)
            Ui_Canvas.SetActive(false);
    }

    public void DisableGame()
    {
        if (Game_Canvas != null)
            Game_Canvas.SetActive(false);

        if (Ui_Canvas != null)
            Ui_Canvas.SetActive(true);
    }
}

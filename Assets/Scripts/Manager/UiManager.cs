using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [Header("Popup Manager")]
    public PopupManager popupManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
}

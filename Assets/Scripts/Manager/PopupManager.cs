using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [Header("UI Panels")]
    public List<UiPanel> panels = new List<UiPanel>();

    private UiPanel activePanel;
    private UiPanel previousPanel;

    private Dictionary<PanelType, UiPanel> uiPanelMap = new Dictionary<PanelType, UiPanel>();

    private void Start()
    {
        InitializeMap();
        previousPanel = GetPanel(PanelType.MainMenu);
    }

    private void InitializeMap()
    {
        foreach (UiPanel panel in panels)
        {
            if (panel != null)
            {
                PanelType type = panel.GetPanelType();
                if (!uiPanelMap.ContainsKey(type))
                {
                    uiPanelMap.Add(type, panel);
                }
            }
        }
    }

    public UiPanel GetPanel(PanelType type)
    {
        uiPanelMap.TryGetValue(type, out UiPanel panel);
        return panel;
    }

    public void ActivatePanel(PanelType type)
    {
        if (previousPanel != null)
            previousPanel.HidePanel();

        activePanel = GetPanel(type);
        previousPanel = activePanel;



        if (activePanel != null)
            activePanel.ShowPanel();
            Debug.Log("Show Panel: " + type);

    }

    public void DeactivatePanel(PanelType type)
    {
        UiPanel panel = GetPanel(type);
        if (panel != null)
            panel.HidePanel();
    }
}

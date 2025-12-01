using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollisionDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        UiManager.Instance.EnablePanel(PanelType.GameOverMenu);
        GameManager.Instance.isGameRunning = false;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CheckPoint_Controller : MonoBehaviour
{
    [SerializeField] private Transform ParentCheckPoint;

    private List<GameObject> checkPoints = new List<GameObject>();
    private Compass compass;
    private int currentcheckpoint = 0;

    void Start()
    {
        compass = FindAnyObjectByType<Compass>();
    }

    public void InitCheckpoint()
    {
        foreach (Transform child in ParentCheckPoint)
        {
            if (child.gameObject.activeSelf)
            {
                checkPoints.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
        }
        checkPoints[0].SetActive(true);
        compass.UpdateTarget(checkPoints[0].transform);
    }

    public void nextCheckPoint()
    {
        checkPoints[currentcheckpoint].SetActive(false);
        if (checkPoints.Count-1 != currentcheckpoint)
        {
            currentcheckpoint++;
            checkPoints[currentcheckpoint].SetActive(true);
            compass.UpdateTarget(checkPoints[currentcheckpoint].transform);
        }
    }
}

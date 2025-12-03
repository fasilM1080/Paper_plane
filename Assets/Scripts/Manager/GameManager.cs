using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [NonSerialized]public bool isGameRunning = false;
    private GameObject plane;
    private Vector3 planeStartPos = new Vector3(0, 0, 0);
    private Quaternion planeStartRot = new Quaternion(0, 0, 0, 0);

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        plane = GameObject.FindWithTag("Player");
        planeStartPos = plane.transform.position;
        planeStartRot = plane.transform.rotation;
    }

    public void ResetGame()
    {
        plane.transform.position = planeStartPos;
        plane.transform.rotation = planeStartRot;
    }
    
}

using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPoint_Controller checkPoint_Controller;
    void Start()
    {
     checkPoint_Controller = FindAnyObjectByType<CheckPoint_Controller>();   
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkPoint_Controller.nextCheckPoint();
        }
    }
}

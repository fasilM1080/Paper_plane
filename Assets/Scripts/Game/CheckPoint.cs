using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPoint_Controller checkPoint_Controller;
    private Transform target;
    private bool isInside =false;
    void Start()
    {
     checkPoint_Controller = FindAnyObjectByType<CheckPoint_Controller>();   
     target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (!isInside)
        {
            lookAt();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkPoint_Controller.nextCheckPoint();
            isInside = false;
        }
    }

    void lookAt()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        if(direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * 5f // rotation speed
            );
        }
    }
}

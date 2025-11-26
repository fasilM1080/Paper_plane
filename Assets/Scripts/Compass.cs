using Unity.VisualScripting;
using UnityEngine;

public class Compass : MonoBehaviour
{
    private Transform target;

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction,Vector3.up);

            transform.rotation = rotation;   
        }
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

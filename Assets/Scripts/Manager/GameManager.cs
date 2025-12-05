using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [NonSerialized]public bool isGameRunning = false;
    [NonSerialized]public int currentlevel;
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject planebody;
    private Collider collider;
    private MeshRenderer mesh;

    void Awake()
    {
       Instance = this;
    }
    void Start()
    {
        collider = planebody.GetComponent<Collider>();
        mesh = planebody.GetComponent<MeshRenderer>();
    }

    public void ContinueGame()
    {
        collider.enabled = false;
        StartCoroutine(NonintractiveCollider());
        StartCoroutine(BlinkRoutine(5f, 0.2f));
        isGameRunning = true;
    }

    IEnumerator NonintractiveCollider()
    {
        yield return new WaitForSeconds(5f);
        collider.enabled = true;
    }
     IEnumerator BlinkRoutine(float duration, float speed)
    {
        float timer = 0f;

        while (timer < duration)
        {
            mesh.enabled = !mesh.enabled;
            yield return new WaitForSeconds(speed);
            timer += speed;
        }

        mesh.enabled = true; // reset
    }
}

using System.Collections.Generic;

using UnityEngine;

public class SegmentGenerator : MonoBehaviour

{

    [Header("Segment")]
    [SerializeField] private GameObject[] Prefabs;

    [Header("Player and Floor Settings")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float floorLength;
    [SerializeField] private int maxSegmentCount;
    [SerializeField] private int initialSegmentCount;
    private float spawnZ = 0;
    private Queue<GameObject> segmentPool = new();
    private Queue<GameObject> Active = new();

    void Awake()
    {
        Init();
    }

    void Start()

    {

        for (int i = 0; i < initialSegmentCount; i++)

        {

            spawnSegment();

        }

    }





    void Update()

    {

        if (playerTransform.position.z > spawnZ - (floorLength * maxSegmentCount))

        {

            spawnSegment();

            returnSegment();

        }

    }

    private void Init()

    {
        for (int i = 0; i < 3*maxSegmentCount; i++)
        {
            GameObject prefab = Prefabs[Random.Range(0,Prefabs.Length)];
            GameObject newSegment = Instantiate(prefab);
            newSegment.SetActive(false);
            segmentPool.Enqueue(newSegment);
        }
    }

    

    private void spawnSegment()

    {

        Vector3 spawnPoint = new Vector3(0, 0, spawnZ);

        GameObject newSegment = segmentPool.Dequeue();

        newSegment.transform.position = spawnPoint;

        newSegment.SetActive(true);

        Active.Enqueue(newSegment);

        spawnZ += floorLength;

    }



    private void returnSegment()

    {

        if (segmentPool.Count > maxSegmentCount+1)

        {
            GameObject oldSegment = Active.Dequeue();
            oldSegment.SetActive(false);
            segmentPool.Enqueue(oldSegment);
        }

    }

}
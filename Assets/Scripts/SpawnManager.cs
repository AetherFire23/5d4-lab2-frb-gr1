using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 2f;
    private float repeatDelay = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
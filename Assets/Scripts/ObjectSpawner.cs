using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner Instance;
    public List<GameObject> spawnedItems;
    
    public Vector3 spawnVelocity;
    public float maxAngularVelocity = 25;
    public float spawnInterval = 5;

    private Queue<GameObject> spawnQueue;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObject", 3);
        spawnQueue = new Queue<GameObject>(spawnedItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject()
    {
        GameObject newMovable = spawnQueue.Dequeue();
        GameObject spawnedObject = Instantiate(newMovable, transform.position, Quaternion.identity);

        Rigidbody spawnedBody = spawnedObject.GetComponent<Rigidbody>();
        spawnedBody.velocity = spawnVelocity;
        spawnedBody.rotation = Random.rotation;
        spawnedBody.angularVelocity = new Vector3(Random.Range(0, maxAngularVelocity), Random.Range(0, maxAngularVelocity), Random.Range(0, maxAngularVelocity));

        if (spawnQueue.Count > 0)
        {
            Invoke("SpawnObject", spawnInterval);

        }
    }
}

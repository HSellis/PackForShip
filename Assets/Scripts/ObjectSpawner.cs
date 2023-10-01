using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner Instance;
    public List<GameObject> spawnedItems;

    //public Vector3 spawnVelocity;
    public float spawnVelocityModifier = 2;
    public float spawnVectorRandomizer = 0.25f;
    public float maxAngularVelocity = 10;
    public float spawnInterval = 5;

    public bool isGameEnd = false;

    private Queue<GameObject> spawnQueue;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnQueue = new Queue<GameObject>(spawnedItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(spawnQueue.Dequeue(), transform.position, Quaternion.identity);

        Rigidbody spawnedBody = spawnedObject.GetComponent<Rigidbody>();
        spawnedBody.velocity = spawnVelocityModifier * new Vector3(
            transform.forward.x + Random.Range(-spawnVectorRandomizer, spawnVectorRandomizer),
            transform.forward.y + Random.Range(-spawnVectorRandomizer, spawnVectorRandomizer),
            transform.forward.z + Random.Range(-spawnVectorRandomizer, spawnVectorRandomizer)
        ).normalized;
        spawnedBody.rotation = Random.rotation;
        spawnedBody.angularVelocity = new Vector3(Random.Range(0, maxAngularVelocity), Random.Range(0, maxAngularVelocity), Random.Range(0, maxAngularVelocity));

        if (spawnQueue.Count > 0 && !isGameEnd)
        {
            Invoke("SpawnObject", spawnInterval);

        }
    }
}

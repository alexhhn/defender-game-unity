using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] girlsPrefabs;
    private float spawnRangeX = 25;
    private float spawnPosZ = 33;
    private float startDelay = 1;
    private float spawnInterval = 1;
    private int lastSpawnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn mæber randomly
        InvokeRepeating("SpawnRandomGirls", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Spawn random mæber at random x position at end of play area
    void SpawnRandomGirls()
    {
        //Generate random mæber index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        // instantiate animal at random spawn location
        int girlsIndex = Random.Range(0, girlsPrefabs.Length);

        // Decrease the chance of spawning enemy at the same position
        if (girlsIndex == lastSpawnIndex)
        {
            girlsIndex = Random.Range(0, girlsPrefabs.Length);
        }

        Instantiate(girlsPrefabs[girlsIndex], spawnPos, girlsPrefabs[girlsIndex].transform.rotation);
        girlsIndex = lastSpawnIndex;

    }

}

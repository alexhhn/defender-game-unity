using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] girlsPrefabs;
    private float spawnRangeX = 4.5f;
    private float spawnPosZ = 5.5f;
    private float startDelay = 1;
    private float spawnInterval = 0;
    private int lastSpawnIndex = 0;

    //Spawn power-ups
    public GameObject[] powerupsPrefabs;
    private float spawnPowerRangeX = 4.5f;
    public float spawnPowerPosZ = -3f;
    public float startDelayPower = 1;
    public float spawnPowerInterval = 5;

    //Player
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        //Spawn mæber randomly
        InvokeRepeating("SpawnRandomGirls", startDelay, spawnInterval);

        //Spawn power-ups
        InvokeRepeating("SpawnPowerUps", startDelayPower, spawnPowerInterval);
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

        // instantiate mæber at random spawn location
        int girlsIndex = Random.Range(0, girlsPrefabs.Length);

        // Decrease the chance of spawning enemy at the same position
        if (girlsIndex == lastSpawnIndex)
        {
            girlsIndex = Random.Range(0, girlsPrefabs.Length);
        }

        Instantiate(girlsPrefabs[girlsIndex], spawnPos, girlsPrefabs[girlsIndex].transform.rotation);
        girlsIndex = lastSpawnIndex;

    }
    void SpawnPowerUps()
    {
        float playerPosition = Player.transform.position.x;
        // hvis x er 2
        // -4.5 

        float leftPos = Random.Range(-spawnPowerRangeX, playerPosition - 1);
        float rightPos = Random.Range(playerPosition + 1, spawnPowerRangeX);
        // Debug.Log(leftPos + "left");
        // Debug.Log(rightPos + "right");
        //Generate random power-ups index and random spawn position
        float random = Random.Range(0, 100);

        Debug.Log(random + "random");

        Vector3 spawnPosPowerups;
        if (random > 50)
        {
            spawnPosPowerups = new Vector3(leftPos, 0, spawnPowerPosZ);
        }
        else
        {
            spawnPosPowerups = new Vector3(rightPos, 0, spawnPowerPosZ);
        }

        // instantiate mæber at random spawn location
        int powerupsIndex = Random.Range(0, powerupsPrefabs.Length);

        // Decrease the chance of spawning enemy at the same position
        if (powerupsIndex == lastSpawnIndex)
        {
            powerupsIndex = Random.Range(0, powerupsPrefabs.Length);
        }

        Instantiate(powerupsPrefabs[powerupsIndex], spawnPosPowerups, powerupsPrefabs[powerupsIndex].transform.rotation);
        powerupsIndex = lastSpawnIndex;

    }
}

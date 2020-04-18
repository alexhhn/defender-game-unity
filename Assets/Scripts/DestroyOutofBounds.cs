using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 35;
    private float bottomBound = -37;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If an object goes past the player in the game, remove that object
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}

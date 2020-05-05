using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGameOver : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}

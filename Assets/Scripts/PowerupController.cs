using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public ProjectileController projectileController;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("on trigger enter");


        if (collision.GetComponent<Collider>().tag == "Player")
        {

            // StartCoroutine(ScaleProjectile());
            gameManager.TriggerScalePowerUp();
            Destroy(gameObject);

        }

    }

}

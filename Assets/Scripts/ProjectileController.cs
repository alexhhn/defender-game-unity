﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30.0f;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        var rot = transform.rotation;
        rot.x = 0;
        transform.localScale = new Vector3(gameManager.projectileSize, gameManager.projectileSize, gameManager.projectileSize);

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.GetComponent<Collider>().tag == "Enemy")
        {
            Destroy(collision.gameObject);
            // Destroy(gameObject);
            // Debug.Log(gameManager);
            gameManager.UpdateScore(1);

            FindObjectOfType<SoundManager>().Play("Throwing sound");
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

    }
}

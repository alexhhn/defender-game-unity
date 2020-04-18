﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotateSpeed = 30f;

    public float horizontalInput;
    public float verticalInput;
    public Animator animator;
    public GameObject projecttilePrefab;

    public float xRangeleft = 18f;
    public float xRangeright = 23.0f;
    private float zRange = 32.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("init");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);
        // transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * movementSpeed);

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Debug.Log("movement" + movement);
        if (movement != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projecttilePrefab, new Vector3(transform.position.x, projecttilePrefab.transform.position.y, transform.position.z), projecttilePrefab.transform.rotation);
        }
        // Player move in range
        if (transform.position.x < -xRangeleft)
        {
            transform.position = new Vector3(-xRangeleft, transform.position.y, transform.position.z);

        }
        if (transform.position.x > xRangeright)
        {
            transform.position = new Vector3(xRangeright, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
}
using System.Collections;
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

        // if (horizontalInput < 0)
        // {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        // transform.Rotate(0.0f, -90.0f, 0.0f);
        // }
        // else if (horizontalInput > 0)
        // {
        //     transform.Rotate(0.0f, 90.0f, 0.0f);
        // }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotateSpeed = 0.15f;

    public float horizontalInput;
    public float verticalInput;
    public Animator animator;
    public GameObject projecttilePrefab;


    // Start is called before the first frame update
    void Start()
    {
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

        if (animator.GetBool("isAttacking") == false)
        {
            Debug.Log(animator.GetBool("isAttacking"));
            animator.SetBool("isRunning", false);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotateSpeed);
        }

        if (movement != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(animator.enabled);
            Instantiate(projecttilePrefab, new Vector3(transform.position.x, projecttilePrefab.transform.position.y, transform.position.z), projecttilePrefab.transform.rotation);
            animator.SetBool("isAttacking", true);
        }

        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     animator.enabled = false;
        //     animator.SetBool("isAttacking", true);

        // }



    }
}

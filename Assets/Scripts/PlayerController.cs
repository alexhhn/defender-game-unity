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
    private float fireRate = 0.5f; // time the player has to wait to fire again
    private float nextFire = 0; // time since start after which player can fire again

    private float xRange = 24.0f;
    private float zRange = 32.0f;

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

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        // ? Temporarly commented out 
        // float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);

        if (animator.GetBool("isAttacking") == false)
        {
            animator.SetBool("isRunning", false);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotateSpeed);
            }
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
            ShootProjectile();
        }


        // Player move in range
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
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
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // This function is also called on UI
    public void ShootProjectile()
    {
        if (Time.time > nextFire)
        {
            Vector3 resetMovement = new Vector3(0f, 0f, 0f);
            nextFire = Time.time + fireRate;
            Instantiate(projecttilePrefab, new Vector3(transform.position.x, projecttilePrefab.transform.position.y, transform.position.z + 1), projecttilePrefab.transform.rotation);
            transform.rotation = transform.rotation = Quaternion.identity;
            animator.SetBool("isAttacking", true);
        }
    }
}

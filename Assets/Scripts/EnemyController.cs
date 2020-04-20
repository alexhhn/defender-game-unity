using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // anim.enabled = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // anim.Play("Run_InPlace");

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    void Start()
    {
        var rot = transform.rotation;
        rot.x = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.GetComponent<Collider>().tag == "Enemy")
        {
            Debug.Log("projectile hits");
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }
}

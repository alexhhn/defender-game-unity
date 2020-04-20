using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    public GameObject coronaAura;
    public int hasCoronaChance = 25;

    // Start is called before the first frame update
    void Start()
    {
        float coronaRange = Random.Range(0, 100);
        if (hasCoronaChance > coronaRange)
        {
            coronaAura.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }
}

using UnityEngine;
using System.Collections;
#pragma warning disable 0618
[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour
{
    void Update()
    {
        GetComponent<ParticleSystem>().startSize = transform.lossyScale.magnitude;
    }
}
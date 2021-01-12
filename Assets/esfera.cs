using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esfera : MonoBehaviour
{    
    ParticleSystem p;
    MeshRenderer m;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            p = GetComponent<ParticleSystem>();
            m = GetComponent<MeshRenderer>();
            m.enabled = false;
            p.Play();
            Destroy(this.gameObject, 0.2f);
        }
    }
}

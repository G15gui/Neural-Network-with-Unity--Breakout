using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorRandom : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
    }
}

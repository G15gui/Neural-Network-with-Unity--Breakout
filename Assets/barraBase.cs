using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraBase : MonoBehaviour
{
    public controller c;

    public float DistX;
    //public float DistY;
    public float v = 0.05f;

    Vector3 vel;

    float[] input = new float[2];
    public NeuralNetwork network;
    
    int position;

    public int pts = 0;

    public GameObject[] b;

    void Start()
    {
        vel = new Vector3(v, 0, 0);
    }


    void Update()
    {
        b = GameObject.FindGameObjectsWithTag("Respawn");

        DistX = b[0].transform.position.x - transform.position.x;

        if(DistX < 10 || DistX > -10)
        {
            for(int i = 0; i < 2; i++)
            {
                if(DistX > 0.25f || DistX < -0.25f)
                {
                    input[i] = DistX + 0.25f;
                }
                else 
                {
                    input[i] = 0;
                }
            }

            float[] output = network.FeedForward(input);

            //if(transform.position.x < 8 && transform.position.x > -8)
            {
                transform.position += vel * output[0];
                //transform.position -= vel * output[1];
            }

        }
    }

    public void UpdateFitness()
    {
        network.fitness = position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Respawn"))
        {
            pts++;
            GameObject g = GameObject.FindWithTag("pts");
            Text textPts = g.GetComponentInChildren<Text>();
            textPts.text = pts.ToString();
        }
    }
}
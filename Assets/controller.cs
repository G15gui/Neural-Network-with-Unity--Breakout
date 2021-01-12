using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public GameObject[] b;
    public GameObject prefab;

    float startTime;
    float timer = 15;
    public int ptsperda = 0;

    public Text textTimer;
    public Text textPerda;
    Manager m;

    void Awake()
    {
        m = GetComponent<Manager>();
        timer = m.timeframe;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            timer = m.timeframe;
            ptsperda = 0;
            textPerda.text = ptsperda.ToString();
        }


        
        timer -= Time.deltaTime;
        textTimer.text = ""+Mathf.CeilToInt(timer);
        

        b = GameObject.FindGameObjectsWithTag("Respawn");

        if(b.Length < 2 && b[b.Length - 1].transform.position.y <= 6) 
        {
            Instantiate(prefab, new Vector3(Random.Range(-8, 8), 10, 0), prefab.transform.rotation);
        }

        if(b[0].transform.position.y < -2)
        {
            Destroy(b[0]);
            attPerda();
        }
    }

    public void attPerda()
    {
        ptsperda++;
        textPerda.text = ptsperda.ToString();
    }

}

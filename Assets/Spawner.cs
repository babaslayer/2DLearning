using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
   
    [SerializeField] float timer ;
    [SerializeField] float speed = 3f;
    void Start()
    {
        
    }

    void Spawn()
    {
        timer = 3;
        Instantiate(obstacle, new Vector2 (10,Random.Range(-3f,1.5f)), transform.rotation);
  
    }
    // Update is called once per frame
    void Update()
    {
        

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Spawn();



        }

      


    }
}

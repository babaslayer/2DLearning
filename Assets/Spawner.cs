using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject coin;
    [SerializeField] float timer_coin;
    [SerializeField] float timer_obstacle ;
   
    void Start()
    {
        
    }

    void SpawnObstacle()
    {
        timer_obstacle = 3;
        Instantiate(obstacle, new Vector2 (10,Random.Range(-3f,1.5f)), transform.rotation);
  
    }
    // Update is called once per frame
    void Update()
    {
        if (timer_coin <= 0)
        {
            SpawnCoin();
        }
        timer_coin -= Time.deltaTime;
        timer_obstacle -= Time.deltaTime;


        if (timer_obstacle <= 0)
        {
            SpawnObstacle();

        }


        if (timer_coin < 0)
        {

            SpawnCoin();

        }
        void SpawnCoin()
        {
            timer_coin = 0.5f;
            Instantiate(coin, new Vector2(11f, Random.Range(-4f, 4f)), transform.rotation);



        }


    }
}

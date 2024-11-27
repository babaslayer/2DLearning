using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject coin;
    [SerializeField] float timer_coin;
    [SerializeField] float timer_obstacle;
    [SerializeField] List<GameObject> coinPatterns;
   
    void Start()
    {
        
    }

    void SpawnObstacle()
    {
        if (timer_obstacle <= 0)
        {
            timer_obstacle = 3;
            Instantiate(obstacle, new Vector2(10, Random.Range(-3f, 1.5f)), transform.rotation);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
        TimerObjects();
        SpawnCoin();
        SpawnObstacle();    
       

        





    }
    void SpawnCoin()
    {
        if (timer_coin < 0)
        {
            timer_coin = 5f;

            int randomIndex = Random.Range(0,coinPatterns.Count);
            GameObject selectedPattern = coinPatterns[randomIndex];
            GameObject spawnedCoin = Instantiate(selectedPattern,transform.position,transform.rotation);         

        }

    }
    void TimerObjects()
    {


        timer_coin -= Time.deltaTime;
        timer_obstacle -= Time.deltaTime;


    }
}

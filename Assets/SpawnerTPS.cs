using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTPS : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] float Spawn›nternal=2f;
    [SerializeField] float timer;
    [SerializeField] Vector2 minDistance;
    [SerializeField] Vector2 maxDistance;
    

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;  
        if (timer <= 0)
        {
            SpawnEnemy();
        }

    }
    void SpawnEnemy()
    {
        timer = Spawn›nternal;
        float randomx = Random.Range(minDistance.x, maxDistance.x);
        float randomy= Random.Range(minDistance.y, maxDistance.y);
        Vector2 spawnLocation = new Vector2(randomx, randomy);

        Instantiate(EnemyPrefab, spawnLocation, Quaternion.identity);//Quaternion.identy nesnenin rotasyonunu s˝f˝rlar.

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((minDistance + maxDistance) / 2, maxDistance - minDistance);
    }


}

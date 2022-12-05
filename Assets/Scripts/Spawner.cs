using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objsToSpawn;
    public Transform[] spawnPlaces;
    public GameObject bomb;
    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minForce = 12;
    public float maxForce = 17;

    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];


            GameObject go = null;
            float p = Random.Range(0, 100);

            if(p < 15)
            {
                go = bomb;
            }
            else
            {
                go = objsToSpawn[Random.Range(0, objsToSpawn.Length)];
            }

            GameObject fruit = Instantiate(go, t.position, t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse); 

            Debug.Log("Fruits spawned");

            Destroy(fruit, 5);

        }
    }

    
}


//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SectorGeneration : MonoBehaviour
{
    public GameObject asteroids;
    public int minAsteroidNumber;
    public int maxAsteroidNumber;
    public int radius;
    public int insideRad;
    public bool Donut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Generate();
        }
    }

    public void Generate()
    {
        int asteroidNumber = Random.Range(minAsteroidNumber, maxAsteroidNumber);
        
        

        for(int i =0; i < asteroidNumber; i++)
        {
            float spawnX = Random.Range(transform.position.x - radius, transform.position.x + radius);
            float maxY = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(spawnX - transform.position.x, 2));
            float spawnY = Random.Range(transform.position.y - maxY, transform.position.y + maxY);
            float angle = Random.Range(0, 360);

            
            if (Donut)
            {
              if(Mathf.Pow(spawnX - transform.position.x,2) + Mathf.Pow(spawnY - transform.position.y, 2) > Mathf.Pow(insideRad, 2))
                {
                    Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
                    GameObject newThing = Instantiate(asteroids, spawnPos, Quaternion.Euler(0, 0, angle));
                    newThing.transform.SetParent(this.gameObject.transform);
                }
                else
                {
                    asteroidNumber++;
                }
            }
            else
            {
                Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
                GameObject newThing = Instantiate(asteroids, spawnPos, Quaternion.Euler(0, 0, angle));
                newThing.transform.SetParent(this.gameObject.transform);
            }
            


            
        }
    }
}


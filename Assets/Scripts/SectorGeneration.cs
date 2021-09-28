
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.VFX;

public class SectorGeneration : MonoBehaviour
{
    public GameObject[] asteroids;
    public float minScale;
    public float maxScale;
    public int minAsteroidNumber;
    public int maxAsteroidNumber;
    public int radius;
    public int insideRad;
    public bool Donut;

    


    public GameObject passage;

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
        int asteroidAmount = Random.Range(minAsteroidNumber, maxAsteroidNumber);
       
        /*
            float spawnXP = Random.Range(transform.position.x - radius, transform.position.x + radius);
            float maxYP = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(spawnXP - transform.position.x, 2));

            float chanceOf = Random.Range(1, 10);
            float spawnYP;

        if (chanceOf > 4)
        {
            spawnYP = transform.position.y - maxYP;
        }
        else
        {
            spawnYP = transform.position.y + maxYP;
        }
            
            Vector3 spawnPosP = new Vector3(spawnXP, spawnYP, 0);
            */
   
        
        //float angleP = 

            /*GameObject newPass = Instantiate(passage, spawnPosP, Quaternion.Euler(0, 0, 0));
            Vector3 Direction = newPass.transform.position - transform.position;
            float angleP = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            newPass.transform.rotation = Quaternion.Euler(0, 0, angleP + 90);
            newPass.transform.SetParent(this.gameObject.transform);*/ 
       


        for (int i =0; i < asteroidAmount; i++)
        {
            float spawnX = Random.Range(transform.position.x - radius, transform.position.x + radius);
            float maxY = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(spawnX - transform.position.x, 2));
            float spawnY = Random.Range(transform.position.y - maxY, transform.position.y + maxY);
            float angle = Random.Range(0, 360);
            float scale = Random.Range(minScale, maxScale);
            int countNumbr = Random.Range(0, asteroids.Length);

           

            if (Donut)
            {
                if (Mathf.Pow(spawnX - transform.position.x, 2) + Mathf.Pow(spawnY - transform.position.y, 2) > Mathf.Pow(insideRad, 2))
                {
                    Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
                    GameObject newThing = Instantiate(asteroids[countNumbr], spawnPos, Quaternion.Euler(0, 0, angle));
                    newThing.transform.localScale *= scale; 
                    newThing.transform.SetParent(this.gameObject.transform);
                }
                else
                {
                   
                    
                    
                    
                    
                    int tryCount = 1;
                    for(int j = 0; j < tryCount; j ++)
                    {
                       spawnY = Random.Range(transform.position.y - maxY, transform.position.y + maxY);
                       if (Mathf.Pow(spawnX - transform.position.x, 2) + Mathf.Pow(spawnY - transform.position.y, 2) > Mathf.Pow(insideRad, 2))
                       {
                            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
                            GameObject newThing = Instantiate(asteroids[countNumbr], spawnPos, Quaternion.Euler(0, 0, angle));
                            newThing.transform.localScale *= scale;
                            newThing.transform.SetParent(this.gameObject.transform);
                       }
                        else
                        {
                            tryCount++;
                        }
                     }
                   
                }
            }
            else if(!Donut)
            {
                Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
                GameObject newThing = Instantiate(asteroids[countNumbr], spawnPos, Quaternion.Euler(0, 0, angle));
                newThing.transform.localScale *= scale;
                newThing.transform.SetParent(this.gameObject.transform);
            }
           
             
            

            
        }
    }
}


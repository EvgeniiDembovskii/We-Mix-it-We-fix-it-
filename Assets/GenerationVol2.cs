using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationVol2 : MonoBehaviour
{
    public GameObject[] asteroids;
    public float minScale;
    public float maxScale;
    public int minAsteroidNumber;
    public int maxAsteroidNumber;
    public int radius;
    public int minRad;

    [SerializeField] private AnimationCurve densityPerDist;

    //public float angle;

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

        //Debug.Log(densityPerDist.Evaluate(10) + "Evaluation");

        for (int i = 0; i < asteroidAmount; i++)
        {
            float angle = Random.Range(0, 360);

            float cDist = Random.Range(minRad, radius);
            //float cDist = radius;
            float aKatet = cDist * Mathf.Sin(angle);
            float bKatet = cDist * Mathf.Cos(angle);

            float spawnX = transform.position.x + bKatet;
            float spawnY = transform.position.y + aKatet;

            Vector3 asteroidPos = new Vector3(spawnX, spawnY, 0);

            int countNumbr = Random.Range(0, asteroids.Length);
            float scale = Random.Range(minScale, maxScale);

            float dice = Random.Range(0,100);
            float chance = densityPerDist.Evaluate(cDist);
            //float chance = cDist/2;
            //float chance = -1;
            if (dice < chance)
            {
                GameObject newThing = Instantiate(asteroids[countNumbr], asteroidPos, Quaternion.Euler(0, 0, angle));
                newThing.transform.localScale *= scale;
                newThing.transform.SetParent(this.gameObject.transform);
            } else
            {
                asteroidAmount++;
                Debug.Log("RESPAWNING");
            }

           

        }

        
    }
}

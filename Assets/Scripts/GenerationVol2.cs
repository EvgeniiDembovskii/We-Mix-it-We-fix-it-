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

    [SerializeField] private AnimationCurve densityPerDist1;
    [SerializeField] private AnimationCurve densityPerDist2;
    [SerializeField] private AnimationCurve densityPerDist3;

    public int type;

    //public float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void Generate()
    {
        int asteroidAmount = Random.Range(minAsteroidNumber, maxAsteroidNumber);

        //Debug.Log(densityPerDist.Evaluate(10) + "Evaluation");

        //type = GetComponentInParent<PassageBuilder>().genValue;

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
            float chance = 0;
            if (type == 0) {
                 chance = densityPerDist1.Evaluate(cDist);
            }else if(type == 1)
            {
                 chance = densityPerDist2.Evaluate(cDist);
            }else
            {
                 chance = densityPerDist3.Evaluate(cDist);
            }
           
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float dist;
    public int damage;
    public float lifeTime;
    //public GameObject Ship[];
    

    // Update is called once per frame
    void Update()
    {
        GameObject[] Ship;
        Ship = GameObject.FindGameObjectsWithTag("Player");
        dist = Vector2.Distance(transform.position, Ship[0].transform.position);
        lifeTime -= Time.deltaTime;

        if (dist >= 10 || lifeTime<=0)
        {
            Destroy(gameObject);
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int health;
    private int defaulthealth;
    public GameObject details;

    private MassCalculator massCount;

    void Start()
    {
        defaulthealth = health;
        massCount = GetComponentInParent<MassCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( health <= 0)
        {
            this.gameObject.SetActive(false);

            if (massCount != null) 
            { 
                massCount.Calculate();
                Debug.Log("ObjectDestroyed_And_Mass_Calculated");
            }

            if (!this.gameObject.transform.root.CompareTag("Player"))
            {
                GameObject newDetails = Instantiate(details, this.transform.position, this.transform.rotation);
            }
           
            health = defaulthealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            BulletScript bullet = other.gameObject.GetComponent<BulletScript>();
            int damage = bullet.damage;
            
            health = health - damage;
            Debug.LogWarning("1damage");
            Destroy(other.gameObject);
            
        }


       
    }

}

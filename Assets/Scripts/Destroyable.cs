using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int health;
    private int defaulthealth;
    public GameObject details;

    private MassCalculator massCount;
    private DissolveEffect dissolveScript;

    void Start()
    {
        defaulthealth = health;
        massCount = GetComponentInParent<MassCalculator>();
        // dissolveScript = GetComponent<DissolveEffect>();
        dissolveScript = gameObject.AddComponent<DissolveEffect>();
       // GetComponent<SpriteRenderer>().material = 
    }

    // Update is called once per frame
    void Update()
    {
        if ( health <= 0)
        {
            dissolveScript.dissolving = true;

            if (dissolveScript.fade == 1f)
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
                dissolveScript.fade = 0f;
                dissolveScript.dissolving = false;
               
            }
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

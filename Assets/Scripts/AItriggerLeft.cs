using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AItriggerLeft : MonoBehaviour
{
    public GameObject AIship;
   
    private AIshipBechavior brainScript;
    private float dist;
    void Start()
    {
        brainScript = AIship.GetComponent<AIshipBechavior>();
       
    }

    // Update is called once per frame

   


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dist = Vector2.Distance(AIship.transform.position, other.transform.position);
            Debug.DrawLine(AIship.transform.position, other.transform.position);

            if (dist < 4)
            {
                brainScript.DodgeLeft = true;
            }
            else
            {
                brainScript.DodgeLeft = false;
            }
           
        }

        if (other.gameObject.CompareTag("Player"))
        {
            brainScript.PlayerDetectedLeft = true;
        }




    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            brainScript.DodgeLeft = false;
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            brainScript.PlayerDetectedLeft = false;
            
        }
    }

    
}

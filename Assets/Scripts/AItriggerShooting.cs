using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AItriggerShooting : MonoBehaviour
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
        brainScript = AIship.GetComponent<AIshipBechavior>();
        if (other.gameObject.CompareTag("Player"))
        {
            brainScript.ShootEm = true;
            dist = Vector2.Distance(AIship.transform.position, other.transform.position);
            Debug.DrawLine(AIship.transform.position, other.transform.position);

            if (dist < 3)
            {
                brainScript.FullStop = true;
            }
            else
            {
                brainScript.FullStop = false;
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            dist = Vector2.Distance(AIship.transform.position, other.transform.position);
            Debug.DrawLine(AIship.transform.position, other.transform.position);

            if (dist < 2)
            {
                brainScript.FullStop = true;
            }
            else
            {
                brainScript.FullStop = false;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        brainScript = AIship.GetComponent<AIshipBechavior>();
        if (other.gameObject.CompareTag("Player"))
        {
            brainScript.ShootEm = false;
            brainScript.FullStop = false;

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            brainScript.FullStop = false;
        }
    }
}

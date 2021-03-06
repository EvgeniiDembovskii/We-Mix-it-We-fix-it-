using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AItriggerRight : MonoBehaviour
{
    public GameObject AIship;
    private AIshipBechavior brainScript;
    private float dist;
    private List<GameObject> enemiesClose = new List<GameObject>();
    void Start()
    {
        brainScript = AIship.GetComponent<AIshipBechavior>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (enemiesClose.Count != 0)
        {
            for(int i=0; i < enemiesClose.Count; i++)
            {
                if (enemiesClose[i].gameObject != null)
                {
                    dist = Vector2.Distance(enemiesClose[i].transform.position, AIship.transform.position);
                    if (dist < 4)
                    {
                        brainScript.DodgeRight = true;
                    }
                    else
                    {
                        brainScript.DodgeRight = false;
                    }
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (brainScript == null) { brainScript = AIship.GetComponent<AIshipBechavior>(); }
        if (other.gameObject.CompareTag("Player"))
        {
            brainScript.PlayerDetectedRight = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesClose.Add(other.gameObject);
            
            
            
            //dist = Vector2.Distance(AIship.transform.position, other.transform.position);
            //Debug.DrawLine(AIship.transform.position, other.transform.position);

           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (brainScript == null) { brainScript = AIship.GetComponent<AIshipBechavior>(); }
        if (other.gameObject.CompareTag("Player"))
        {
            brainScript.PlayerDetectedRight = false;
            
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            brainScript.DodgeRight = false;
            enemiesClose.Remove(other.gameObject);
        }
    }
}

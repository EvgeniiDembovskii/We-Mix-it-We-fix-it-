using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineScript : MonoBehaviour
{
    //public GameObject ship;
    private Rigidbody2D shipRB;
    private GameObject[] ship;
    public string myKey  ;
    public string myKey2 ;
    public float speed;
   // public Text debug;
    public Sprite EngineOn;
    public Sprite EngineOFF;

    public bool notAI;
    public bool triggered;



    void Awake()
    {
        speed = 1.2f;
        //debug.text = "-";
        notAI = true;
        triggered = false;
    }
    private void Start()
    {
        shipRB = this.gameObject.GetComponentInParent<Rigidbody2D>();
        
        if (notAI)
        {
            //ship = GameObject.FindGameObjectsWithTag("Player");
            //shipRB = ship[0].GetComponent<Rigidbody2D>();
            //this.gameObject.GetComponentInParent
            //Debug.Log("notAI");
            // GetCo
        }
        else if (notAI == false)
        {
            //ship = null;
            //shipRB = null;
        }
    }

    public void Initialyze()
    {
        Debug.Log("Something");
    }

    void FixedUpdate()
    {
       
            // Input.inputString.
            if (Input.GetKey(myKey)&& notAI)
            {
                EngineAct();
            }
            else if (Input.GetKey(myKey2)&& notAI)
            {
                EngineAct();
            }
            else if (triggered)
            {
                EngineAct();
             //debug.text = " TRIGGERED";
            }
            else
            {
                EngineOff();
            }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
        }
    }

    public void EngineAct ()
    {
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 myDirection;
        myDirection = this.gameObject.transform.TransformDirection(Vector2.up);
        shipRB.AddForceAtPosition(myDirection * speed, myPos);
       // Debug.DrawLine(this.gameObject.transform.position, shipRB.position);
        //debug.text = " Kinda works";
        this.gameObject.GetComponent<SpriteRenderer>().sprite = EngineOn;
        
    }

    public void EngineOff()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = EngineOFF;
    }
}

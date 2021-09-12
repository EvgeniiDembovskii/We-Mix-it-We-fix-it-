using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Player;
    public GameCycleManager manager;
    public GameObject camCraine;
    public GameObject camCraine2;


    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    private GameObject[] AllEnemies;
    //public Transform closestEnemy;
    private GameObject CurrentTarget;
    private GameObject latestTargetUpdate;
    private GameObject previousTarget;
    private Animator ac;
    public float dist;

    //public GameObject randomAI;

    public bool Switch;    
    // Start is called before the first frame update
    void Start()
    {
        ac = this.GetComponent<Animator>();
        rb = camCraine.GetComponent<Rigidbody2D>();
        rb2 = camCraine2.GetComponent<Rigidbody2D>();
        CurrentTarget = null;
        previousTarget = null;
        Switch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GameStarted)
        {
            ac.SetBool("Menu", true);
            //Debug.LogWarning("WORKS also FINE!");
        }
        else if (!manager.GameStarted)
        {
            ac.SetBool("Menu", false);
            //Debug.LogWarning("WORKS FINE!");
        }





        // CurrentTarget = getClosestEnemy();

        latestTargetUpdate = getClosestEnemy();
        //Debug.Log(latestTargetUpdate);

        if (latestTargetUpdate != CurrentTarget)
        {
            if (CurrentTarget != null)
            {
                previousTarget = CurrentTarget;
            }
            CurrentTarget = latestTargetUpdate;
            //Debug.Log("New Target");
            //Debug.Log(previousTarget + "prev");
            //Debug.Log(CurrentTarget + "cur");

            if (Switch)
            {
                Switch = false;
            }else if(!Switch)
            {
                Switch = true;
            }
        }

        if (latestTargetUpdate != null )
        {


            if (Switch)
            {
                ac.SetBool("TargetSwitch", false);
                Vector3 Direction = CurrentTarget.transform.position - camCraine.transform.position;
                float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

                rb.rotation = angle + 90;
                camCraine.transform.position = Player.transform.position;

                if (previousTarget != null)
                {

                    Vector3 Direction1 = previousTarget.transform.position - camCraine2.transform.position;
                    float angle1 = Mathf.Atan2(Direction1.y, Direction1.x) * Mathf.Rad2Deg;

                    rb2.rotation = angle1 + 90;
                    camCraine2.transform.position = Player.transform.position;
                }
            }
            else if (!Switch)
            {
                ac.SetBool("TargetSwitch", true);
                Vector3 Direction = previousTarget.transform.position - camCraine.transform.position;
                float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

                rb.rotation = angle + 90;
                camCraine.transform.position = Player.transform.position;

                Vector3 Direction1 = CurrentTarget.transform.position - camCraine2.transform.position;
                float angle1 = Mathf.Atan2(Direction1.y, Direction1.x) * Mathf.Rad2Deg;

                rb2.rotation = angle1 + 90;
                camCraine2.transform.position = Player.transform.position;
            }






            dist = Vector2.Distance(Player.transform.position, CurrentTarget.transform.position);
            
           
            if (dist > 15)
            {
                ac.SetBool("CameraState", false);
            }
            else if (dist <= 15)
            {
                ac.SetBool("CameraState", true);
            }

        } else
        {
            ac.SetBool("CameraState", false);
        }
       


    }

    public GameObject getClosestEnemy()
    {
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestSoFar = Mathf.Infinity;
        GameObject target = null;

        foreach (GameObject go in AllEnemies)
        {
            float currentDist;
            currentDist = Vector2.Distance(Player.transform.position, go.transform.position);
            if( currentDist< closestSoFar)
            {
                closestSoFar = currentDist;               
                target = go.gameObject;
                
                
            }
        }

        
        return target;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIshipBechavior : MonoBehaviour
{

    public GameObject engine1;
    public GameObject engine2;
    public GameObject engine3;
    public GameObject engine4;
    public GameObject engine5;

    public GameObject gun1;
    public GameObject gun2;

    private EngineScript engine1Script;
    private EngineScript engine2Script;
    private EngineScript engine3Script;
    private EngineScript engine4Script;
    private EngineScript engine5Script;

    private Shooting gun1Script;
    private Shooting gun2Script;

    public bool PlayerDetectedLeft;
    public bool PlayerDetectedRight;
    public bool ShootEm;
    public bool DodgeLeft;
    public bool DodgeRight;
    public bool FullStop;

   

    

    // Update is called once per frame
    void Start()
    {
        engine1Script = engine1.GetComponent<EngineScript>();
        engine2Script = engine2.GetComponent<EngineScript>();
        engine3Script = engine3.GetComponent<EngineScript>();
        engine4Script = engine4.GetComponent<EngineScript>();
        engine5Script = engine5.GetComponent<EngineScript>();


        engine1Script.notAI = false;
        engine2Script.notAI = false;
        engine3Script.notAI = false;
        engine4Script.notAI = false;
        engine5Script.notAI = false;
        PlayerDetectedLeft = false;
        PlayerDetectedRight = false;

        DodgeLeft = false;
        DodgeRight = false;

        gun1Script = gun1.GetComponent<Shooting>();
        gun2Script = gun2.GetComponent<Shooting>();

        gun1Script.GunNotAi = false;
        gun2Script.GunNotAi = false;
        ShootEm = false;

        FullStop = false;

       
    }


    private void FixedUpdate()
    {
        if(FullStop)
        {
            engine3Script.triggered = false;
            engine4Script.triggered = true;
            engine1Script.triggered = true;
            engine2Script.triggered = false;
            engine5Script.triggered = false;
        }
        else
        {
            if (DodgeLeft)
            {
                engine4Script.triggered = true;
                engine2Script.triggered = true;
                engine1Script.triggered = false;
                engine3Script.triggered = false;
            }
            else if (DodgeRight)
            {
                engine1Script.triggered = true;
                engine3Script.triggered = true;
                engine4Script.triggered = false;
                engine2Script.triggered = false;
            }
            else if (PlayerDetectedLeft)
            {
                engine1Script.triggered = true;
                engine2Script.triggered = true;
                engine3Script.triggered = false;
                engine4Script.triggered = false;
            }
            else if (PlayerDetectedRight)
            {
                engine3Script.triggered = true;
                engine4Script.triggered = true;
                engine1Script.triggered = false;
                engine2Script.triggered = false;
            }
            else
            {
                engine1Script.triggered = false;
                engine2Script.triggered = false;
                engine3Script.triggered = false;
                engine4Script.triggered = false;
            }

            if (ShootEm)
            {
                gun1Script.GunTriggered = true;
                gun2Script.GunTriggered = true;
                engine5Script.triggered = true;

            }
            else
            {
                gun1Script.GunTriggered = false;
                gun2Script.GunTriggered = false;
                engine5Script.triggered = false;
            }
        }

       
       
        
    }

   
}

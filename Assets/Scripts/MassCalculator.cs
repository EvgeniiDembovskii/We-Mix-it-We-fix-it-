using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float mass;
    private UgaBoogaTag[] blocks;
    private Healing detailsScript;
    

    public GameCycleManager manager;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        detailsScript = GetComponentInParent<Healing>();
       
    }

    private void Update()
    {
        blocks = GetComponentsInChildren<UgaBoogaTag>();
        Debug.Log(blocks.Length);

       

       
       
        mass = (blocks.Length + 1) * 0.25f;
        rb.mass = mass;

        if (!manager.GameStarted)
        {
            detailsScript.detailsCollected = detailsScript.detailsOverallCollected - (blocks.Length * 25);
        }
    }
    // Update is called once per frame
    public void Calculate()
    {
        
       
    }
}

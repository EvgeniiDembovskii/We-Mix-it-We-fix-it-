using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float MoveSpeed; 
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool rotationNeeded;
    private float dist;
    public float field;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //MoveSpeed = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player;
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            dist = Vector2.Distance(Player.transform.position, transform.position);
            Vector3 Direction = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            if (rotationNeeded)
            {
                rb.rotation = angle + 90;
            }
            Direction.Normalize();
            movement = Direction;
            //Debug.Log(angle);
        }
    }

    private void FixedUpdate()
    {
        if (dist <= field)
        {
            MoveCharacter(movement);
        }
        
    }

    void MoveCharacter (Vector2 Direction)
    {
        rb.MovePosition((Vector2)transform.position + (Direction * MoveSpeed * Time.deltaTime));
    }

   
}

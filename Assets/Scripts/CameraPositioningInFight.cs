using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioningInFight : MonoBehaviour
{
    public Transform Enemy;
    public Transform Ship;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = Enemy.position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
       
        rb.rotation = angle + 90;
        transform.position = Ship.transform.position;

    }
}

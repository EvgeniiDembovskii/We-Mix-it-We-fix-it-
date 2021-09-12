using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    public Transform ship;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = ship.transform.position;
        Vector2 CameraPos = new Vector2(10, 10);
        transform.position = CameraPos;
    }
}

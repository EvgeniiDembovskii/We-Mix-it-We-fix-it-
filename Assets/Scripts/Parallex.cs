using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    public Transform cam1;
    public float movepower = .3f;
    public bool global;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!global)
        {
            transform.localPosition = new Vector3(cam1.position.x * movepower, cam1.position.y * movepower, 20);
        }
        else
        {
            transform.position = new Vector3(cam1.position.x * movepower, cam1.position.y * movepower, 20);
        }
       
        
    }
}

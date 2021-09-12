using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject killer;

    // Update is called once per frame
    void Update()
    {
        if (killer.activeSelf == false)
        {
            this.gameObject.SetActive(false);
            
        }
    }
}

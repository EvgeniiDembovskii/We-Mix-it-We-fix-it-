using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownValueHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public string inputKey1 ;
    public string inputKey2 ;

    public GameObject menu1;
    public GameObject menu2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleInput1(int val)
    {
        if(val == 0)
        {
            inputKey1 = "q";
        }
        if (val == 1)
        {
            inputKey1 = "e";
        }
        if (val == 2)
        {
            inputKey1 = "w";
        }
        if (val == 3)
        {
            inputKey1 = "a";
        }
        if (val == 4)
        {
            inputKey1 = "s";
        }
        if (val == 5)
        {
            inputKey1 = "d";
        }
        if (val == 6)
        {
            inputKey1 = "mouse 0";
        }
        if (val == 7)
        {
            inputKey1 = "mouse 1";
        }
    }

    public void HandleInput2(int val)
    {
        if (val == 0)
        {
            inputKey2 = "q";
        }
        if (val == 1)
        {
            inputKey2 = "e";
        }
        if (val == 2)
        {
            inputKey2 = "w";
        }
        if (val == 3)
        {
            inputKey2 = "a";
        }
        if (val == 4)
        {
            inputKey2 = "s";
        }
        if (val == 5)
        {
            inputKey2 = "d";
        }
        if (val == 6)
        {
            inputKey2 = "mouse 0";
        }
        if (val == 7)
        {
            inputKey2 = "mouse 1";
        }
    }

    public void SetMenu(int val)
    {
        if (val == 0)
        {
            menu1.SetActive(false);
            menu2.SetActive(false);
        }else if (val == 1)
        {
            menu1.SetActive(true);
            menu2.SetActive(false);
        }
        else if (val == 2)
        {
            menu1.SetActive(true);
            menu2.SetActive(true);
        }
    }

}

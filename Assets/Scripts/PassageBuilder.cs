using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageBuilder : MonoBehaviour
{
    private GameObject[] sectorsAll;
    //private GameObject[] closeSectors;
    private List<GameObject> closeSectors = new List<GameObject>();

    public GameObject gap;
    public GameObject chosenSector;
    
    public int checker;
    public int radius;

    public int genValue;
    public bool works = false;
    public bool connected;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //genValue = 0;
        sectorsAll = GameObject.FindGameObjectsWithTag("sector");
        checker = sectorsAll.Length;
        //chosenSector = null;
        //Generate();
    }

    // Update is called once per frame
    void Update()
    {
        //checkConnections();
    }

    public void generateValue()
    {
        chosenSector.GetComponent<PassageBuilder>().genValue++;
    }

    public void AssigneType()
    {
       
        if (genValue == 0)
        {
            if(chosenSector.GetComponent<PassageBuilder>().genValue == 1)
            {
                GetComponentInChildren<GenerationVol2>().type = 3;
            }
            else
            {
                GetComponentInChildren<GenerationVol2>().type = 0;
            }
            
        }
        else if (genValue == 1)
        {
            GetComponentInChildren<GenerationVol2>().type = 1;
        }
        else if (genValue >= 2)
        {
            
            GetComponentInChildren<GenerationVol2>().type = 2;
        }
        Debug.Log("TypeAssigned" + genValue);
    }

    public void editType()
    {
        if (genValue >= 2 && chosenSector.GetComponent<PassageBuilder>().genValue >= 2)
        {

            chosenSector.GetComponentInChildren<GenerationVol2>().type = 1;
        }
    }
    public void GeneratePassages()
    {
        sectorsAll = GameObject.FindGameObjectsWithTag("sector");
        if (sectorsAll.Length != 1)
        {


            for (int i = 0; i < sectorsAll.Length; i++)
            {
                float dist = Vector2.Distance(transform.position, sectorsAll[i].transform.position);

                if (dist <= (radius * 2) + 1)
                {
                    closeSectors.Add(sectorsAll[i]);
                }
            }


            int tryCount = 1;
            for (int i = 0; i < tryCount; i++)
            {
                int index = Random.Range(0, closeSectors.Count);
                chosenSector = closeSectors[index];
                if (chosenSector.GetComponent<PassageBuilder>().chosenSector == gameObject)
                {
                    tryCount++;
                }
            }

            


            float xPos = transform.position.x - ((transform.position.x - chosenSector.transform.position.x) / 2);
            float yPos = transform.position.y - ((transform.position.y - chosenSector.transform.position.y) / 2);

            Vector2 passSpawn = new Vector2(xPos, yPos);

            GameObject newGap = Instantiate(gap, passSpawn, Quaternion.Euler(0, 0, 0));
            newGap.transform.SetParent(this.transform);
            
        }

    }

    public void checkConnections()
    {
        if (connected)
        {
            Debug.Log("I AM CONNECTED!");
            chosenSector.GetComponent<PassageBuilder>().connected = true;
            for (int i = 0; i < closeSectors.Count; i++)
            {
                if (closeSectors[i].GetComponent<PassageBuilder>().chosenSector == gameObject)
                {
                    closeSectors[i].GetComponent<PassageBuilder>().connected = true;
                    //Debug.Log("I AM CONNECTED!");
                }
            }
        }
    }

    public void DebugFunction()
    {
        Debug.Log("LOBA IS THICK");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    public GameObject sector;
    public List<GameObject> allSectors = new List<GameObject>() ;
    public int mapWidth;
    public int mapHeight;
    public int distToSector;
    private bool onOFF;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateAll()
    {
        for (int j = 0; j < mapHeight; j++)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                float xPos = transform.position.x + (Mathf.Sqrt(Mathf.Pow(distToSector, 2) - Mathf.Pow(distToSector * 0.5f, 2)) * (i + 1));
                float yPos = new int();
                if (onOFF)
                {

                    yPos = transform.position.y + (distToSector / 2) - (distToSector * j);
                    onOFF = false;
                }
                else
                {
                    yPos = transform.position.y - (distToSector * j);
                    onOFF = true;
                }
                Vector3 SpawnPos = new Vector3(xPos, yPos, 0);
                GameObject newSector = Instantiate(sector, SpawnPos, Quaternion.Euler(0, 0, 0));
                newSector.transform.SetParent(this.gameObject.transform);
                allSectors.Add(newSector);
            }
        }
        int index = allSectors.Count;
        for(int l = 0; l < index; l++)
        {
            //allSectors[l].gameObject.GetComponent<PassageBuilder>().DebugFunction();
            // allSectors[l].gameObject.SetActive(false);
            // allSectors[l].gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
            allSectors[l].gameObject.GetComponent<PassageBuilder>().GeneratePassages();
            //Debug.Log("UGA BUGA"); 

        }
        for (int l = 0; l < index; l++)
        {
           
            allSectors[l].gameObject.GetComponent<PassageBuilder>().AssigneType();
            //Debug.Log("UGA BUGA");

        }

        for (int l = 0; l < index; l++)
        {

            allSectors[l].gameObject.GetComponentInChildren<GenerationVol2>().Generate();
            //Debug.Log("UGA BUGA");

        }


    }
}


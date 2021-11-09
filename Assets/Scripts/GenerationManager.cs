using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    public GameObject sector;
    public List<GameObject> allSectors = new List<GameObject>() ;
    private GameObject[] allEnemies;
    public int mapWidth;
    public int mapHeight;
    public int distToSector;
    private bool onOFF;
    

    public GameObject enemiesHolder;
    
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
       
            allSectors = new List<GameObject>();
            
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

            allSectors[0].GetComponent<PassageBuilder>().connected = true;
            int indexX = allSectors.Count;
            for (int l = 0; l < indexX; l++)
            {

                allSectors[l].gameObject.GetComponent<PassageBuilder>().GeneratePassages();


            }
        //
        int tryCount = 1;
        bool onOff = false;
        for (int y = 0; y < tryCount; y++)
        {
            onOff = false;
            for (int l = 0; l < indexX; l++)
            {
                allSectors[l].gameObject.GetComponent<PassageBuilder>().checkConnections();
            }
            for (int l = 0; l < indexX; l++)
            {
                allSectors[l].gameObject.GetComponent<PassageBuilder>().checkConnections();
            }
            for (int l = 0; l < indexX; l++)
            {
                allSectors[l].gameObject.GetComponent<PassageBuilder>().checkConnections();
            }

            for (int l = 0; l < indexX; l++)
            {
                allSectors[l].gameObject.GetComponent<PassageBuilder>().checkConnections();
                //allSectors[l].gameObject.GetComponent<PassageBuilder>().AssigneType();
                //Debug.Log("UGA BUGA");

            }


            for (int l = 0; l < indexX; l++)
            {
                if (allSectors[l].gameObject.GetComponent<PassageBuilder>().connected == false)
                {


                    //Destroy(allSectors[l].GetComponentInChildren<ustroyDestroy>().gameObject);
                    allSectors[l].GetComponentInChildren<ustroyDestroy>().gameObject.SetActive(false); 
                    allSectors[l].gameObject.GetComponent<PassageBuilder>().GeneratePassages();
                    if (!onOff)
                    {
                        tryCount++;
                        onOff = true;
                    }

                }
            }
        }


        for (int l = 0; l < indexX; l++)
        {

            allSectors[l].gameObject.GetComponent<PassageBuilder>().generateValue();
            //Debug.Log("UGA BUGA");

        }



        //
        for (int l = 0; l < indexX; l++)
        {
            
            allSectors[l].gameObject.GetComponent<PassageBuilder>().AssigneType();
            //Debug.Log("UGA BUGA");

        }

        for (int l = 0; l < indexX; l++)
        {

            allSectors[l].gameObject.GetComponent<PassageBuilder>().editType();
            //Debug.Log("UGA BUGA");

        }

        //end

        int index1 = allSectors.Count;
        for (int l = 0; l < index1; l++)
        {
            //allSectors[l].gameObject.GetComponent<PassageBuilder>().checkConnections();
            allSectors[l].gameObject.GetComponentInChildren<GenerationVol2>().Generate();
            Debug.Log("UGA BUGA");

        }



        for (int l = 0; l < index1; l++)
        {

            allSectors[l].gameObject.GetComponent<Optimization>().activated = true;
            //Debug.Log("UGA BUGA");

        }

        

    }

    
}


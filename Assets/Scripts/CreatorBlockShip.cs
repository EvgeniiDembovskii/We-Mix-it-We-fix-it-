using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class CreatorBlockShip : MonoBehaviour
{
    public GameObject [] blocks;
    public GameObject[] Slots;
    public EngineScript MyEngine;
    public GameObject GameManager;

    private Shooting MyGun;
    private Healing detailst;
    
    
    private DropDownValueHandler inputHandler;

    private GameObject destroy;
    public int blockNumber;
    private int amount;
    private int angle;
    public bool selected;

    
        // Start is called before the first frame update
    void Start()
    {
        amount = blocks.Length;
        blockNumber = -1;
        angle = 0;
        selected = false;
        Slots = GameObject.FindGameObjectsWithTag("spawn");
        detailst = GetComponentInParent<Healing>();
        
       
        inputHandler = GameObject.FindGameObjectWithTag("inputManager").GetComponent<DropDownValueHandler>();

       
       
    }

    // Update is called once per frame
    void Update()
    {
        MyEngine = this.gameObject.GetComponentInChildren<EngineScript>();
        MyGun = this.gameObject.GetComponentInChildren<Shooting>();
        if (MyEngine != null && selected)
        {
            inputHandler.SetMenu(2);

            MyEngine.myKey = inputHandler.inputKey1;
            MyEngine.myKey2 = inputHandler.inputKey2;
            
          
        } else if(MyGun != null && selected)
        {
            inputHandler.SetMenu(1);
            MyGun.myKey = inputHandler.inputKey1;
            
           // Debug.Log("GunSpawned");
        }
        else if (MyEngine == null && MyGun == null && selected )
        {
            inputHandler.SetMenu(0);
            //Debug.Log("Nothing Spawned");
        }
       
    }

    public void spawnMesh()
    {
       
        

            for (int i = 0; i < Slots.Length; i++)
            {
                CreatorBlockShip script = Slots[i].GetComponent<CreatorBlockShip>();
                script.selected = false;
            }


            blockNumber++;
            angle = 0;
            selected = true;
            if (blockNumber >= amount)
            {
                blockNumber = 0;
            }

        if (detailst.detailsCollected > 0)
        {
            GameObject newBlock = Instantiate(blocks[blockNumber], this.transform.position, this.transform.rotation);

            newBlock.transform.SetParent(this.gameObject.transform);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GameObject newBlock = Instantiate(blocks[5], this.transform.position, this.transform.rotation);

            newBlock.transform.SetParent(this.gameObject.transform);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
        }
            
            destroy = this.gameObject.transform.GetChild(0).gameObject;
            if (this.gameObject.transform.childCount > 1)
            {
                Destroy(destroy);

            }
        
        //
        //massCount.Calculate();
    }

    public  void rotateMesh()
    {
        if (selected)
        {
            angle = angle + 90;

            this.gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

   

   
}

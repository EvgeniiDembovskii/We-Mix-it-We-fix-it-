using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{

    public int detailsCollected;
    public int detailsOverallCollected;
    public int NeededAmount;
    public Text counter;
    public GameObject button;


    private void Start()
    {
        detailsOverallCollected = detailsCollected;
    }

    private void Update()
    {
        if(detailsCollected<=0)
        {
            detailsCollected = 0;
        }
        
        if (detailsCollected >= NeededAmount)
        {
            button.SetActive(true);

        }
        else 
        { 
            button.SetActive(false);
        }
        counter.text = "Collected: " + detailsCollected + "\n Needed to repair:" + NeededAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("details"))
        {
            detailsCollected = detailsCollected + 5;
            detailsOverallCollected = detailsOverallCollected + 5;
            //Debug.Log(detailsCollected);
            Destroy(other.gameObject);
      
        }



    }

   

    public void Heal(bool menu)
    {
        Transform[] allChildren = this.transform.GetComponentsInChildren<Transform>(true);
        for(int i =0; i < allChildren.Length; i++)
        {
            allChildren[i].gameObject.SetActive(true);
        }

        if (!menu)
        {
            detailsCollected = detailsCollected - NeededAmount;
            NeededAmount = NeededAmount + 25;
        }
        
    }
}

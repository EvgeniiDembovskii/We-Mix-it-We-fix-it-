using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public int DetailsNeeded;
    public GameObject button;
    private Healing script;
    private GameObject[] enemies;
    public Text textDetails;
    public Text textEnemies;

    private void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<Healing>();
        textDetails.text = "Details for the next level:" + DetailsNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        textEnemies.text = " Enemies left:" + enemies.Length;
       
        if (enemies.Length <=0 && script.detailsCollected >= DetailsNeeded)
       {
            button.SetActive(true);
           // Debug.Log(enemies.Length);
       }
    }

    public void nextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

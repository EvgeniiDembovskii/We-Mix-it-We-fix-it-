using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycleManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemies;

    public GameObject UI;
    public bool GameStarted;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GameStarted = false;
    }

    private void Update()
    {
        if (!GameStarted)
        {
          
            player.transform.rotation = transform.rotation;

            


        }
       
    }

    // Update is called once per frame
    public void StartGame()
    {
        GameStarted = true;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        UI.SetActive(false);
        Enemies.SetActive(true);

    }

    public void StopGame()
    {
        GameStarted = false;
        UI.SetActive(true);
        Enemies.SetActive(false);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        player.GetComponent<Healing>().Heal(true);

    }
}

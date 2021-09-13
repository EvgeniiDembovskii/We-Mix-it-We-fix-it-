using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockScript : MonoBehaviour
{
    public GameCycleManager manager;
    public bool Locked;

    private GameObject player;
    private Vector2 movement;
    private Rigidbody2D rb;

    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameCycleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Locked)
        {
            //player.transform.position = transform.position;
            Vector3 Direction =  transform.position - player.transform.position;
            Direction.Normalize();
            movement = Direction;
            MoveCharacter(movement);
        }

        if (manager.GameStarted)
        {
            Locked = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.GetComponent<Rigidbody2D>();
            player = collision.gameObject;
            manager.StopGame();
            Locked = true;
            //player.transform.position = transform.position;
        }
    }

    void MoveCharacter(Vector2 Direction)
    {
        rb.MovePosition((Vector2)transform.position + (Direction * MoveSpeed * Time.deltaTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnController : MonoBehaviour
{
    public Rigidbody2D rb;
    public columnSpawner columnSpawner;
    public gameManager gameManager;
    bool SpawnedChild = false;
    bool reachedEnd = true;
    public dragonController dragonController;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        columnSpawner = FindObjectOfType<columnSpawner>();
        gameManager = FindObjectOfType<gameManager>();
        dragonController = FindObjectOfType<dragonController>();
    }

    private void Update()
    {
        if (transform.position.x<-0.2f && !SpawnedChild)
        {
            columnSpawner.spawnColumn();
            SpawnedChild = true;
        }

        if (transform.position.x<-1.2f)
        {
            if (reachedEnd)
            {
                gameManager.ScoreUpdater();
            }
            Destroy(gameObject);
        }
        if (transform.position.y < -1f)
        {
            // Make sure fireballs don't destroy the entire gameplay loop!
            if(columnSpawner.ColumnParent.transform.childCount == 1)
            {
                columnSpawner.spawnColumn();
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (reachedEnd)
        {
            reachedEnd = false;
            rb.gravityScale = Random.Range(0.2f, 0.6f);

            if (collision.gameObject.CompareTag("Fireball"))
            {
                Destroy(collision.gameObject);
            }
            else { 
                gameManager.DecreaseMultiplier();
                gameManager.DecreaseScore();
                gameManager.fireballChargerCounter = 0;
                gameManager.fireballReady = false;
                dragonController.dragonAnim.Play("dragon-flashing");
            }
        }

    }
}

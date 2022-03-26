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
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (reachedEnd)
        {
            rb.gravityScale = Random.Range(0.2f, 0.6f);
            reachedEnd = false;
            gameManager.DecreaseMultiplier();
            gameManager.DecreaseScore();
            dragonController.anim.Play("dragon-flashing");
        }
    }
}

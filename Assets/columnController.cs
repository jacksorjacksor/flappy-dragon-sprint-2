using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnController : MonoBehaviour
{
    public Rigidbody2D rb;
    public columnSpawner columnSpawner;
    bool SpawnedChild = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        columnSpawner = FindObjectOfType<columnSpawner>();
    }

    private void Update()
    {
        if (transform.position.x<-0.2f && !SpawnedChild)
        {
            columnSpawner.spawnColumn();
            SpawnedChild = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.gravityScale = Random.Range(0.2f,0.6f);
    }
}

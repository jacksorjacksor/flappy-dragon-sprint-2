using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnSpawner : MonoBehaviour
{
    public Sprite[] colArray;
    float vel = 1f;
    public GameObject colPrefab;
    public GameObject col;

    private void Start()
    {
        spawnColumn();  
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnColumn();
        }
    }
    public void spawnColumn()
    {
        col = (GameObject)Instantiate(colPrefab);
        col.transform.position = new Vector2(1.3f, Random.Range(-0.4f, 0.4f));
        col.GetComponent<SpriteRenderer>().sprite = colArray[Random.Range(0, colArray.Length)];
        col.AddComponent<BoxCollider2D>();
        col.AddComponent<columnController>();
        col.GetComponent<Rigidbody2D>().velocity = Vector2.left * vel;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnSpawner : MonoBehaviour
{
    public Sprite[] colArray;
    public GameObject colPrefab;
    public GameObject col;
    public gameManager gameManager;
    public dragonController dragonController;
    public GameObject ColumnParent;
    private void Start()
    {
        gameManager = FindObjectOfType<gameManager>();
        dragonController = FindObjectOfType<dragonController>();
        ColumnParent = GameObject.Find("ColumnParent");
    }

    public void spawnColumn()
    {
        col = (GameObject)Instantiate(colPrefab);
        col.transform.SetParent(ColumnParent.transform, false);
        col.transform.position = new Vector2(1.3f, dragonController.transform.position.y + Random.Range(-0.1f, 0.1f));
        col.GetComponent<SpriteRenderer>().sprite = colArray[Random.Range(0, colArray.Length)];
        col.AddComponent<BoxCollider2D>();
        col.AddComponent<columnController>();
        col.GetComponent<Rigidbody2D>().velocity = Vector2.left * gameManager.Multiplier;
    }
}

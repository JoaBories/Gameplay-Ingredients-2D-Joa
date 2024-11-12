using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject maxLeft;
    [SerializeField] private GameObject maxRight;

    private bool spawned;

    private void Start()
    {
        spawned = false;
        key.SetActive(false);
        walls.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !spawned)
        {
            spawned = true;
            Boss currentBoss = Instantiate(bossPrefab, new Vector3(61.5f, 8, 0), Quaternion.identity).GetComponent<Boss>();
            currentBoss.maxLeft = maxLeft;
            currentBoss.maxRight = maxRight;
            currentBoss.player = collision.gameObject;
        }
    }
}
